using System.Collections.Generic;

﻿#pragma warning disable CS8618
namespace SPG_Fachtheorie.Aufgabe1.Model;

public class Shipment
{
    protected Shipment() { }

    public Shipment(Customer sender, string trackingNumber, string recipientName,
        Address recipientAddress, decimal weightKg, DeliveryStatus status)
    {
        Sender = sender;
        TrackingNumber = trackingNumber;
        RecipientName = recipientName;
        RecipientAddress = recipientAddress;
        WeightKg = weightKg;
        Status = status;
    }

    public int Id { get; set; }
    public Customer Sender { get; set; }
    public string TrackingNumber { get; set; }
    public string RecipientName { get; set; }
    public Address RecipientAddress { get; set; }
    public decimal WeightKg { get; set; }
    public DeliveryStatus Status { get; set; }
    public Depot? CurrentDepot { get; set; }
    public Driver? AssignedDriver { get; set; }
    public List<DeliveryAttempt> DeliveryAttempts { get; } = new();
}
