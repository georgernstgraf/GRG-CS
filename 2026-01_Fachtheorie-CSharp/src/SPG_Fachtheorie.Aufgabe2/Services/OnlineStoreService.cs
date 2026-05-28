using Microsoft.EntityFrameworkCore;
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

    public List<CategoryWithCountDto> GetCategoriesWithProductCounts()
    {
        return _db.Categories
            .Include(c => c.Products)
            .Select(c => new CategoryWithCountDto(c.Name, c.Products.Count))
            .ToList();
    }

    public List<PreorderDto> GetPreordersOfCustomer(int customerId)
    {
        return _db.Preorders
            .Where(p => p.Customer.Id == customerId)
            .Select(p => new PreorderDto(
                p.Customer.Id,
                p.Customer.FirstName + " " + p.Customer.LastName,
                p.Code,
                p.PlacedAt,
                p.TotalAmount))
            .ToList();
    }

    public ProductWithRevenueDto? GetRevenueOfProduct(int productId)
    {
        return _db.Products
            .Where(p => p.Id == productId)
            .Select(p => new ProductWithRevenueDto(
                p.Id,
                p.Name,
                p.PreorderItems.Sum(pi => pi.Quantity * pi.UnitPrice)))
            .FirstOrDefault();
    }

    public Preorder AddPreorder(int customerId, List<CustomerProductPreorder> productPreorders)
    {
        var customer = _db.Customers.FirstOrDefault(c => c.Id == customerId);
        if (customer is null)
            throw new OnlineStoreException("Invalid CustomerId.");

        if (productPreorders.Count == 0)
            throw new OnlineStoreException("Empty preorders.");

        var preorder = new Preorder(customer, "00000", DateTime.UtcNow, 0);
        _db.Preorders.Add(preorder);

        var preorderItems = productPreorders
            .Select(pp => new
            {
                Product = _db.Products.FirstOrDefault(p => p.Id == pp.ProductId),
                pp.Quantity
            })
            .Where(x => x.Product is not null)
            .Select(x => new PreorderItem(preorder, x.Product!, x.Quantity, x.Product!.Price))
            .ToList();

        preorder.TotalAmount = preorderItems.Sum(pi => pi.Quantity * pi.UnitPrice);
        preorder.PreorderItems.AddRange(preorderItems);
        _db.SaveChanges();

        return preorder;
    }
}
