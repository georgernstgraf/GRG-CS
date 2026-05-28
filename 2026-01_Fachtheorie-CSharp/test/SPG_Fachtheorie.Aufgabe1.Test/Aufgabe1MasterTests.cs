// *************************************************************************************************
// VORDEFINIERTE INTEGRATION TESTS ZUR AUTOMATISIERTEN KONTROLLE
// Hier ist nichts auszufüllen oder zu bearbeiten!
// Sie können die Tests zur Kontrolle ausführen, aber hier wird nichts implementiert.
// Bei der Kontrolle der Abgaben wird diese Datei durch die Originalversion ersetzt.
// *************************************************************************************************
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using System;
using System.Diagnostics;
using Xunit;

namespace SPG_Fachtheorie.Aufgabe1.Test;

/// <summary>
/// Insert-Tests für das neue EF-Core Modell.
/// Diese Tests fügen direkt Daten per SQL ein und prüfen, ob die Tabellen korrekt funktionieren.
/// </summary>
public class Aufgabe1MasterTests
{
    /// <summary>
    /// Prüft, ob alle Tabellen in der Datenbank erstellt wurden.
    /// </summary>
    [Fact]
    public void T00_CanCreateDatabaseTest()
    {
        using var db = GetEmptyDbContext();
        string createScript = db.Database.GenerateCreateScript();
        Debug.Write(createScript);

        using var command = db.Database.GetDbConnection().CreateCommand();
        command.CommandText = $"SELECT COUNT(*) FROM sqlite_master WHERE type='table';";
        db.Database.OpenConnection();
        var result = (long?) command.ExecuteScalar();
        Assert.True(result >= 3, $"Less than 3 Tables found. Check your DbSets.");
    }

    /// <summary>
    /// Prüft, ob die Spalten, etc. der Angabe entsprechen.
    /// </summary>
    [Fact]
    public void T00_GenerateSchemaTest() => InsertRow(
        "INSERT INTO Customer (Firstname, Lastname, Email, Phone, Address_Street, Address_Zip, Address_City, Address_Country) VALUES ('first', 'last', 'x@y.at', '+43123456', 'Street 1', '1050', 'Wien', 'Austria')",
        "INSERT INTO Depot (Code, Name, Address_Street, Address_Zip, Address_City, Address_Country) VALUES ('WIEN1', 'Postfach Schule', 'Street 1', '1050', 'Wien', 'Austria')",
        "INSERT INTO Driver (EmployeeNo, FirstName, LastName, CurrentDepotId) VALUES (1001, 'first', 'last', 1)",
        "INSERT INTO Shipment (SenderId, TrackingNumber, RecipientName, RecipientAddress_Street, RecipientAddress_Zip, RecipientAddress_City, RecipientAddress_Country, WeightKg, Status, CurrentDepotId, AssignedDriverEmployeeNo) VALUES (1, '1001', 'Max Mustermann', 'Spengergasse 20', '1050', 'Wien', 'Austria', 1.23, 'OutForDelivery', 1, 1001)",
        "INSERT INTO DeliveryAttempt (ShipmentId, DriverEmployeeNo, AttemptedAt, Success, Notes) VALUES (1, 1001, '2026-01-14T13:24:23', true, NULL)");
    
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

    private void InsertRowShouldFail(params string[] commandsTexts) => InsertRow(true, true, commandsTexts);
    private void InsertRow(params string[] commandsTexts) => InsertRow(false, true, commandsTexts);
    private void InsertRow(bool foreignKeyCheck, params string[] commandsTexts) => InsertRow(false, foreignKeyCheck, commandsTexts);
    private void InsertRow(bool shouldFail, bool foreignKeyCheck, params string[] commandsTexts)
    {
        using var db = GetEmptyDbContext();
        bool failed = false;
        using (var command = db.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = $"PRAGMA foreign_keys = {(foreignKeyCheck ? 1 : 0)}";
            db.Database.OpenConnection();
            command.ExecuteNonQuery();
        }

        foreach (var commandText in commandsTexts)
        {
            using var command = db.Database.GetDbConnection().CreateCommand();
            command.CommandText = commandText;
            db.Database.OpenConnection();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqliteException e)
            {
                failed = true;
                if (!shouldFail)
                    Assert.Fail($"Query failed: {commandText} with error {e.InnerException?.Message ?? e.Message}");
            }
        }
        if (shouldFail && !failed)
            Assert.Fail($"Query shoud fail, but it dosen't. {string.Join(Environment.NewLine, commandsTexts)}");
    }

    private void EnsureConstraint(string table, string column, string type, bool isPk = false)
    {
        using var db = GetEmptyDbContext();
        using var cmd = db.Database.GetDbConnection().CreateCommand();
        cmd.CommandText = $"PRAGMA table_info({table})";
        db.Database.OpenConnection();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string columnName = reader.GetString(1); // Spaltenname
            string columnType = reader.GetString(2); // Spaltentyp
            bool columnPk = reader.GetBoolean(5); // PK Constraint
            if (columnName.Equals(column, StringComparison.OrdinalIgnoreCase))
            {
                Assert.True(columnType == type, $"Wrong datatype for {table}.{column}. Expected: {type}, given: {columnType}.");
                Assert.True(columnPk == isPk, $"Wrong primary key constraint {table}.{column}. Expected: {isPk}, given: {columnPk}.");
                return;
            }
        }
        Assert.Fail($"Column {table}.{column} not found.");
    }
}

