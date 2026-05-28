#pragma warning disable CS8618
using System;
using System.Collections.Generic;

namespace SPG_Fachtheorie.Aufgabe2.Model;

public class Category
{
    protected Category() { }
    public Category(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; } = new();
}

public class Customer
{
    protected Customer() { }
    public Customer(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<Preorder> Preorders { get; } = new();

}

public class Product
{
    protected Product() { }
    public Product(string name, string description, decimal price, Category category)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public List<PreorderItem> PreorderItems { get; } = new();
}

public class Preorder
{
    protected Preorder() { }
    public Preorder(Customer customer, string code, DateTime placedAt, decimal totalAmount)
    {
        Customer = customer;
        Code = code;
        PlacedAt = placedAt;
        TotalAmount = totalAmount;
    }

    public int Id { get; set; }
    public Customer Customer { get; set; }
    public string Code { get; set; }
    public DateTime PlacedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public List<PreorderItem> PreorderItems { get; } = new();
}

public class PreorderItem
{
    protected PreorderItem() { }
    public PreorderItem(Preorder preorder, Product product, int quantity, decimal unitPrice)
    {
        Preorder = preorder;
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public int Id { get; set; }
    public Preorder Preorder { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
#pragma warning restore CS8618
