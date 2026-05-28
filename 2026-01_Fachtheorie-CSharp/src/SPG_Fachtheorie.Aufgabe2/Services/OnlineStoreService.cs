using SPG_Fachtheorie.Aufgabe2.Infrastructure;
using SPG_Fachtheorie.Aufgabe2.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe2.Services;

public record CategoryWithCountDto(string CategoryName, int ProductCount);
public record PreorderDto(
    int CustomerId, string CustomerName, string PreorderCode,
    DateTime PreorderPlacedAt, decimal PreorderTotalAmount);
public record ProductWithRevenueDto(int ProductId, string ProductName, decimal Revenue);
public record CustomerProductPreorder(int ProductId, int Quantity);

public class OnlineStoreService
{
    private readonly OnlineStoreContext _db;
    public OnlineStoreService(OnlineStoreContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Geben Sie alle Produktkategorien (Category) samt der Anzahl der darin
    /// enthaltenen Produkte zurück.
    /// </summary>
    /// <returns></returns>
    public List<CategoryWithCountDto> GetCategoriesWithProductCounts()
    {
        // TODO: Add your implementation
        throw new NotImplementedException();
    }

    /// <summary>
    /// Geben Sie alle Vorbestellungen (Preorder) eines Kunden zurück. Als Rückgabetyp steht Ihnen
    /// der folgende Record zur Verfügung. Das Property CustomerName soll als Stringverknüpfung mit
    /// dem Muster {FirstName} {LastName} gebildet werden.
    /// </summary>
    public List<PreorderDto> GetPreordersOfCustomer(int customerId)
    {
        // TODO: Add your implementation
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gibt den Umsatz eines Produktes zurück. Um den Umsatz zu berechnen, summieren Sie Preor­
    /// der Item.Quantity * PreorderItem.UnitPrice aller Vorbestellungen (PreorderItem) des Produktes.
    /// 
    /// HINWEIS: Liefern Sie ein einzelnes Produkt zurück, keine Liste.
    /// Verwenden Sie daher FirstOrDefault.
    /// </summary>
    public ProductWithRevenueDto? GetRevenueOfProduct(int productId)
    {
        // TODO: Add your implementation
        throw new NotImplementedException();
    }

    /// <summary>
    /// Legen Sie eine Vorbestellung (Preorder) samt der PreorderItems in der Datenbank an. 
    /// HINWEIS: Legen Sie zuerst eine Preorder mit Code "00000", DateTime.UtcNow für placedAt
    ///          und 0 für totalAmount an.
    ///          Projizieren Sie danach productPreorders in eine temporäre Liste mit
    ///          dem Produkt aus der DB und der Quantity.
    ///          Projizieren Sie danach diese Liste in eine Liste von PreorderItems.
    ///          Zum Schluss berechnen Sie TotalAmount und weisen es dem preorder Objekt zu.
    /// </summary>
    public Preorder AddPreorder(int customerId, List<CustomerProductPreorder> productPreorders)
    {
        // TODO: Add your implementation
        throw new NotImplementedException();
    }
}
