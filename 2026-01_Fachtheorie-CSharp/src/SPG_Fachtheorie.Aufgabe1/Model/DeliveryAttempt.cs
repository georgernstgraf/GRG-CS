#pragma warning disable CS8618
using System;

namespace SPG_Fachtheorie.Aufgabe1.Model;

public class DeliveryAttempt
{
    protected DeliveryAttempt() { }

    public DeliveryAttempt(Shipment shipment, Driver driver, DateTime attemptedAt, bool success, string? notes)
    {
        Shipment = shipment;
        Driver = driver;
        AttemptedAt = attemptedAt;
        Success = success;
        Notes = notes;
    }

    public int Id { get; set; }
    public Shipment Shipment { get; set; }
    public Driver Driver { get; set; }
    public DateTime AttemptedAt { get; set; }
    public bool Success { get; set; }
    public string? Notes { get; set; }
}