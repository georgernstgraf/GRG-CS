using SPG_Fachtheorie.Aufgabe2.Infrastructure;
using SPG_Fachtheorie.Aufgabe2.Model;
using SPG_Fachtheorie.Aufgabe3.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace SPG_Fachtheorie.Aufgabe3.Test;

/// <summary>
/// Testklasse. Verwende _factory, um die Methoden
/// _factory.InitializeDatabase, _factory.GetHttpContent<T>, etc. aufzurufen.
/// Achte immer darauf, _factory.InitializeDatabase aufzurufen, um die Datenbank neu zu erstellen.
/// </summary>
[Collection("Sequential")]
public class CustomersControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly TestWebApplicationFactory _factory;

    public CustomersControllerTests(TestWebApplicationFactory factory)
    {
        _factory = factory;
    }

    /// <summary>
    /// Demo integration test.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetAllCustomersReturns200Test()
    {
        _factory.InitializeDatabase(db =>
        {
            db.Customers.Add(new Customer("first1", "last1", "x1@y.at", "+43123456"));
            db.Customers.Add(new Customer("first2", "last2", "x2@y.at", "+43123456"));
            db.SaveChanges();
        });
        var (statusCode, customers) = await _factory.GetHttpContent<List<CustomerDto>>("/customers");
        Assert.True(statusCode == HttpStatusCode.OK);
        Assert.NotNull(customers);
        Assert.True(customers.Count == 2);
    }

    [Fact]
    public async Task DeleteCustomer_Returns204_WhenCustomerExistsAndHasNoPreorders()
    {
        _factory.InitializeDatabase(db =>
        {
            db.Customers.Add(new Customer("first", "last", "x@y.at", "+43123456"));
            db.SaveChanges();
        });

        var statusCode = await _factory.DeleteHttpContent("/customers/1");
        Assert.Equal(HttpStatusCode.NoContent, statusCode);

        var deleted = _factory.QueryDatabase(db => db.Customers.Any(c => c.Id == 1));
        Assert.False(deleted);
    }

    [Fact]
    public async Task DeleteCustomer_Returns400_WhenCustomerHasPreorders()
    {
        _factory.InitializeDatabase(db =>
        {
            var category = new Category("TestCategory");
            db.Categories.Add(category);
            var product = new Product("TestProduct", "Desc", 10m, category);
            db.Products.Add(product);
            var customer = new Customer("first", "last", "x@y.at", "+43123456");
            db.Customers.Add(customer);
            var preorder = new Preorder(customer, "PRE01", DateTime.UtcNow, 10m);
            db.Preorders.Add(preorder);
            var item = new PreorderItem(preorder, product, 1, 10m);
            db.PreorderItems.Add(item);
            db.SaveChanges();
        });

        var statusCode = await _factory.DeleteHttpContent("/customers/1");
        Assert.Equal(HttpStatusCode.BadRequest, statusCode);
    }

    [Fact]
    public async Task DeleteCustomer_Returns404_WhenCustomerNotFound()
    {
        _factory.InitializeDatabase(db => { });

        var statusCode = await _factory.DeleteHttpContent("/customers/999");
        Assert.Equal(HttpStatusCode.NotFound, statusCode);
    }
}
