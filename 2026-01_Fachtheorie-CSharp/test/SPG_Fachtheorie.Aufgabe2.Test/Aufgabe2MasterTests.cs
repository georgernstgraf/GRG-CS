// *************************************************************************************************
// VORDEFINIERTE INTEGRATION TESTS ZUR AUTOMATISIERTEN KONTROLLE
// Hier ist nichts auszufüllen oder zu bearbeiten!
// Sie können die Tests zur Kontrolle ausführen, aber hier wird nichts implementiert.
// Bei der Kontrolle der Abgaben wird diese Datei durch die Originalversion ersetzt.
// *************************************************************************************************
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SPG_Fachtheorie.Aufgabe2.Infrastructure;
using SPG_Fachtheorie.Aufgabe2.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace SPG_Fachtheorie.Aufgabe2.Test;

public class Aufgabe2MasterTests : IDisposable
{
    private readonly OnlineStoreContext _db;
    private readonly OnlineStoreService _service;
    public Aufgabe2MasterTests()
    {
        _db = GetSeededDbContext();
        _service = new OnlineStoreService(_db);
    }

    public void Dispose()
    {
        _db.Dispose();
    }

    [Fact]
    public void T00_CreateSeededDatabaseForServiceSuccessTest()
    {
        using var db = GetSeededDbContext();
        Assert.True(db.Database.CanConnect());
    }
    [Fact]
    public void T01_GetCategoriesWithProductCountsTest()
    {
        var sql = $@"select c.name as CategoryName, (select count(*) from product p where p.categoryId = c.id) as productCount
        from category c";
        CheckServiceMethodResult(_db, sql, _service.GetCategoriesWithProductCounts,
            $"GetCategoriesWithProductCounts");
    }

    [Fact]
    public void T02_GetPreordersOfCustomerTest()
    {
        var customerIds = _db.Database.SqlQueryRaw<int>("select id from customer").ToList();
        foreach (var customerId in customerIds)
        {
            var sql = $@"select c.id as CustomerId, concat(c.firstName, ' ', c.lastName) as CustomerName,
                p.code as PreorderCode, p.placedAt as PreorderPlacedAt, p.totalAmount as PreorderTotalAmount
                from preorder p inner join customer c on (p.customerId = c.id)
                where c.id = {customerId};";
            CheckServiceMethodResult(_db, sql, () => _service.GetPreordersOfCustomer(customerId),
                $"GetPreordersOfCustomer({customerId})");
        }
    }


    [Fact]
    public void T03_GetRevenueOfProductTest()
    {
        var productIds = _db.Database.SqlQueryRaw<int>("select id from product").ToList();
        foreach (var productId in productIds)
        {
            var sql = $@"select p.id as ProductId, p.name as ProductName,
                (select sum(pi.quantity * pi.unitPrice) from preorderItem pi where pi.productId = p.id) as Revenue
                from product p
                where p.id = {productId}";
            CheckServiceMethodResult(_db, sql, () => new[] { _service.GetRevenueOfProduct(productId)! }.ToList(),
                $"GetRevenueOfProduct({productId})");
        }
    }

    [Fact]
    public void T04_AddPreorderThrowsExceptionWhenCustomerIdIsInvalidTest()
    {
        var preorders = new List<CustomerProductPreorder>()
        {
            new CustomerProductPreorder(1, 1),
            new CustomerProductPreorder(2, 3),
        };
        var ex = Assert.Throws<OnlineStoreException>(() => _service.AddPreorder(999, preorders));
        ex.Message.ToLower().Contains("customerid");
    }

    [Fact]
    public void T04_AddPreorderThrowsExceptionWhenProductListIsEmptyTest()
    {
        var preorders = new List<CustomerProductPreorder>();
        var ex = Assert.Throws<OnlineStoreException>(() => _service.AddPreorder(1, preorders));
        ex.Message.ToLower().Contains("pre­orders");
    }

    [Fact]
    public void T04_AddPreorderSuccessTest()
    {
        var preorderCount = _db.Preorders.Count(p => p.Customer.Id == 2);
        var preorderItemsCount = _db.PreorderItems.Count(pi => pi.Preorder.Customer.Id == 2);
        var preorders = new List<CustomerProductPreorder>()
        {
            new CustomerProductPreorder(1, 1),
            new CustomerProductPreorder(2, 3),
        };
        _service.AddPreorder(2, preorders);
        _db.ChangeTracker.Clear();
        Assert.True(_db.Preorders.Count(p => p.Customer.Id == 2) == preorderCount + 1);
        Assert.True(_db.PreorderItems.Count(pi => pi.Preorder.Customer.Id == 2) == preorderItemsCount + 2);
    }
    private void CheckServiceMethodResult<T>(DbSet<T> set, string sql, Func<List<T>> serviceMethod, string methodName) where T : class =>
        CheckServiceMethodResult(set.FromSqlRaw(sql).ToList(), sql, serviceMethod, methodName);
    private void CheckServiceMethodResult<T>(OnlineStoreContext db, string sql, Func<List<T>> serviceMethod, string methodName) where T : class =>
        CheckServiceMethodResult(db.Database.SqlQueryRaw<T>(sql).ToList(), sql, serviceMethod, methodName);
    private void CheckServiceMethodResult<T>(List<T> rows, string sql, Func<List<T>> serviceMethod, string methodName) where T : class
    {
        var serviceResult = serviceMethod();
        Assert.True(serviceResult.Count == rows.Count, $"{methodName} row count failed: expected {rows.Count}, got {serviceResult.Count}.");
        foreach (var row in rows)
            Assert.True(serviceResult.Any(m => JsonSerializer.Serialize(m) == JsonSerializer.Serialize(row)),
                $"Test failed. Row not found in your result: {JsonSerializer.Serialize(row)}.");
    }

    private OnlineStoreContext GetSeededDbContext()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        var options = new DbContextOptionsBuilder()
            .UseSqlite(connection)
            .Options;

        var db = new OnlineStoreContext(options);
        db.Database.EnsureCreated();
        db.Seed();
        return db;
    }

    private List<T> QueryDatabase<T>(DatabaseFacade database, string commandText, Func<DbDataReader, T> projection)
    {
        using var command = database.GetDbConnection().CreateCommand();
        command.CommandText = commandText;
        database.OpenConnection();
        using var reader = command.ExecuteReader();
        var rows = new List<T>();
        while (reader.Read())
            rows.Add(projection(reader));
        return rows;
    }
}