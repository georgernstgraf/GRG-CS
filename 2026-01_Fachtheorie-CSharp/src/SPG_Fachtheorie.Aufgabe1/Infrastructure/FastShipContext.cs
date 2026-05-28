using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Model;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe1.Infrastructure;

public class FastShipContext : DbContext
{
    // TODO: Add your DbSets

    public FastShipContext(DbContextOptions options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: Add your config.


        // Stellt sicher, dass die Tabellen nach dem vorgegebenen Namensschema erzeugt werden.
        // Muss die letzte Anweisung der Config sein.
        // Ohne dieses Schema laufen die vordefinierten INSERT Tests nicht durch.
        ApplyNamingConventions(modelBuilder);
    }
    private void ApplyNamingConventions(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(t => !t.IsOwned()))
        {
            // Tabellen werden wie die Klassennamen benannt und klein geschrieben.
            var clrName = entityType.ClrType.Name;
            entityType.SetTableName(clrName);
        }
    }
}
