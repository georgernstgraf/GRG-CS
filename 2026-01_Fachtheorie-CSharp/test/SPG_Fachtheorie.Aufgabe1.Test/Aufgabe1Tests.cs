// *************************************************************************************************
// UNITTESTS FÜR AUFGABE 1
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
    /// Vorgegebener Test. Prüft, ob die Datenbank überhaupt aus dem Model mit EF Core erzeugt werden kann.
    /// </summary>
    [Fact]
    public void CreateDatabaseTest()
    {
        using var db = GetEmptyDbContext();
        // CREATE TABLE Skript mit dem Debugger angesehen werden (wenn nötig).
        var sqlScript = db.Database.GenerateCreateScript();
        Assert.True(db.Database.CanConnect());
    }

    /// <summary>
    /// PersistDeliveryAttemptTest weist nach, dass eine Zustellung (Shipment) samt Zustellversuch 
    /// (DeliveryAttempt) gespeichert werden kann.
    /// </summary>
    [Fact]
    public void T01_PersistDeliveryAttemptTest()
    {
        // TODO: Add your implementation.
        throw new NotImplementedException();
    }

    /// <summary>
    /// EnsureDepotCodeIsUniqueTest weist nach, dass Depot.Code nicht doppelt gespeichert werden kann.
    /// </summary>
    [Fact]
    public void T02_EnsureDepotCodeIsUniqueTest()
    {
        // TODO: Add your implementation.
        throw new NotImplementedException();
    }

    /// <summary>
    /// EnsureTrackingNumberIsUniqueTest weist nach, dass Shipment.TrackingNumber nicht dop­pelt gespeichert werden kann.
    /// </summary>
    [Fact]
    public void T03_EnsureTrackingNumberIsUniqueTest()
    {
        // TODO: Add your implementation.
        throw new NotImplementedException();
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