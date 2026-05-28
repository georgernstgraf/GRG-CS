using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SPG_Fachtheorie.Aufgabe2.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe2.Infrastructure
{
    public class OnlineStoreContext : DbContext
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Preorder> Preorders => Set<Preorder>();
        public DbSet<PreorderItem> PreorderItems => Set<PreorderItem>();

        public OnlineStoreContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Tabellennamen basieren auf Entity-Namen (nicht DbSet) und starten klein
                var clrName = entityType.ClrType.Name;
                var tableName = char.ToLowerInvariant(clrName[0]) + clrName[1..];
                entityType.SetTableName(tableName);

                foreach (var property in entityType.GetProperties())
                {
                    var propName = property.Name;
                    // Spaltenname: Nur erster Buchstabe klein
                    property.SetColumnName(char.ToLowerInvariant(propName[0]) + propName[1..]);

                    // Standardkonfigurationen
                    if (property.ClrType == typeof(string) && property.GetMaxLength() is null)
                        property.SetMaxLength(255);

                    if (property.ClrType == typeof(DateTime)) property.SetPrecision(3);
                    if (property.ClrType == typeof(DateTime?)) property.SetPrecision(3);
                }

                // FK-Verhalten
                foreach (var fk in entityType.GetForeignKeys())
                    fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public void Seed()
        {
            Randomizer.Seed = new Random(1518);
            var faker = new Faker("de");
            var categories = GenerateDistinct(f => new Category(f.Commerce.ProductMaterial()), 3, c => c.Name);
            var customers = Generate(f => new Customer(
                f.Name.FirstName(), f.Name.LastName(), f.Internet.Email(),
                $"+43{f.Random.Int(100, 999)}{f.Random.Int(10000000, 99999999)}"), 10);
            var products = GenerateDistinct(f => new Product(
                f.Commerce.ProductName(), f.Lorem.Sentence(),
                f.Random.Int(1000, 9999) / 100M, f.Random.ListItem(categories)), 15, p => p.Name);
            var preorder = Generate(f =>
            {
                var preorder = new Preorder(
                    f.Random.ListItem(customers), f.Random.Int(10000, 99999).ToString(),
                    f.Date.Between(new DateTime(2025, 1, 1), new DateTime(2026, 1, 1)),
                    0);
                var preorderItems = new Faker<PreorderItem>().CustomInstantiator(f =>
                    {
                        var product = f.Random.ListItem(products);
                        var quantity = f.Random.Int(1, 3);
                        return new PreorderItem(
                            preorder, product, quantity, product.Price);
                    })
                .Generate(f.Random.Int(1, 3))
                .ToList();
                preorder.TotalAmount = preorderItems.Sum(p => p.Quantity * p.UnitPrice);
                preorder.PreorderItems.AddRange(preorderItems);
                return preorder;
            }, 30);
        }
        private List<T> Generate<T>(Func<Faker, T> generator, int count) where T : class
        {
            var data = new Faker<T>("de")
                .CustomInstantiator(generator)
                .Generate(count)
                .ToList();
            var set = Set<T>();
            set.AddRange(data);
            SaveChanges();
            return data;
        }

        private List<T> GenerateDistinct<T, Tkey>(Func<Faker, T> generator, int count, params Func<T, Tkey>[] distinctBys) where T : class
        {
            var dataEnumerable = new Faker<T>("de")
                .CustomInstantiator(generator)
                .GenerateForever();
            foreach (var distinctBy in distinctBys)
                dataEnumerable = dataEnumerable.DistinctBy(distinctBy);
            var data = dataEnumerable.Take(count).ToList();
            var set = Set<T>();
            set.AddRange(data);
            SaveChanges();
            return data;
        }
    }
}
