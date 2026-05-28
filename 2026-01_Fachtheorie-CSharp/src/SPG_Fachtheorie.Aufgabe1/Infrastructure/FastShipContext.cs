using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Model;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe1.Infrastructure;

public class FastShipContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Depot> Depots => Set<Depot>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<DeliveryAttempt> DeliveryAttempts => Set<DeliveryAttempt>();

    public FastShipContext(DbContextOptions options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.OwnsOne(e => e.Address);
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
        });

        modelBuilder.Entity<Depot>(entity =>
        {
            entity.OwnsOne(e => e.Address);
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.HasIndex(e => e.Code).IsUnique();
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.EmployeeNo);
            entity.Property(e => e.EmployeeNo).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.OwnsOne(e => e.RecipientAddress);
            entity.Property(e => e.TrackingNumber).HasMaxLength(255);
            entity.Property(e => e.RecipientName).HasMaxLength(255);
            entity.Property(e => e.WeightKg).HasPrecision(9, 3);
            entity.Property(e => e.Status).HasConversion<string>().HasMaxLength(255);
            entity.HasIndex(e => e.TrackingNumber).IsUnique();
        });

        modelBuilder.Entity<DeliveryAttempt>(entity =>
        {
            entity.Property(e => e.Notes).HasMaxLength(255);
        });

        ApplyNamingConventions(modelBuilder);
    }
    private void ApplyNamingConventions(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(t => !t.IsOwned()))
        {
            var clrName = entityType.ClrType.Name;
            entityType.SetTableName(clrName);
        }
    }
}
