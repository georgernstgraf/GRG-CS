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

    // TODO: Add your integration tests for DELETE
}
