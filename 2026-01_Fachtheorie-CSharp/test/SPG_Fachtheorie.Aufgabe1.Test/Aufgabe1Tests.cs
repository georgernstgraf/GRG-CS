// *************************************************************************************************
// UNITTESTS F�R AUFGABE 1
// *************************************************************************************************
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using SPG_Fachtheorie.Aufgabe1.Model;
using System;
using System.Linq;
using Xunit;

namespace SPG_Fachtheorie.Aufgabe1.Test;

public class Aufgabe1Tests
{
    /// <summary>
    /// Vorgegebener Test. Pr�ft, ob die Datenbank �berhaupt aus dem Model mit EF Core erzeugt werden kann.
    /// </summary>
    [Fact]
    public void CreateDatabaseTest()
    {
        using var db = GetEmptyDbContext();
        // CREATE TABLE Skript mit dem Debugger angesehen werden (wenn n�tig).
        var sqlScript = db.Database.GenerateCreateScript();
        Assert.True(db.Database.CanConnect());
    }

    [Fact]
    public void T01_PersistDeliveryAttemptTest()
    {
        using var db = GetEmptyDbContext();

        var customer = new Customer("Max", "Mustermann", "max@test.at", "+43123456",
            new Address("Teststr 1", "1050", "Wien", "Austria"));
        var depot = new Depot("WIEN1", "Depot Wien", new Address("Depotstr 5", "1050", "Wien", "Austria"));
        var driver = new Driver(1001, "Hans", "Fahrer", depot);
        var shipment = new Shipment(customer, "TRACK001", "Empfaenger",
            new Address("Zielstr 10", "1020", "Wien", "Austria"), 2.5m, DeliveryStatus.OutForDelivery)
        {
            CurrentDepot = depot,
            AssignedDriver = driver
        };
        var attempt = new DeliveryAttempt(shipment, driver, DateTime.UtcNow, true, "Zugestellt");

        db.Customers.Add(customer);
        db.Depots.Add(depot);
        db.Drivers.Add(driver);
        db.Shipments.Add(shipment);
        db.DeliveryAttempts.Add(attempt);
        db.SaveChanges();

        Assert.True(db.DeliveryAttempts.Count() == 1);
    }

    [Fact]
    public void T02_EnsureDepotCodeIsUniqueTest()
    {
        using var db = GetEmptyDbContext();

        var depot1 = new Depot("WIEN1", "Depot Wien", new Address("Str 1", "1050", "Wien", "Austria"));
        var depot2 = new Depot("WIEN1", "Depot Wien Zwei", new Address("Str 2", "1050", "Wien", "Austria"));

        db.Depots.Add(depot1);
        db.Depots.Add(depot2);

        var ex = Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => db.SaveChanges());
    }

    [Fact]
    public void T03_EnsureTrackingNumberIsUniqueTest()
    {
        using var db = GetEmptyDbContext();

        var customer = new Customer("Max", "Mustermann", "max@test.at", "+43123456",
            new Address("Teststr 1", "1050", "Wien", "Austria"));
        var depot = new Depot("WIEN1", "Depot Wien", new Address("Depotstr 5", "1050", "Wien", "Austria"));

        var shipment1 = new Shipment(customer, "TRACK001", "Empf1",
            new Address("Addr 1", "1010", "Wien", "Austria"), 1.0m, DeliveryStatus.Created);
        var shipment2 = new Shipment(customer, "TRACK001", "Empf2",
            new Address("Addr 2", "1020", "Wien", "Austria"), 2.0m, DeliveryStatus.Created);

        db.Customers.Add(customer);
        db.Depots.Add(depot);
        db.Shipments.Add(shipment1);
        db.Shipments.Add(shipment2);

        var ex = Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => db.SaveChanges());
    }

    private FastShipContext GetEmptyDbContext()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        var options = new DbContextOptionsBuilder()
            .UseSqlite(connection)
            .Options;

        var db = new FastShipContext(options);
        db.Database.EnsureCreated();
        return db;
    }

}