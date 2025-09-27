using System;
using System.Collections.Generic;

namespace quiz.Models;

public partial class PrismaMigration
{
    public string Id { get; set; } = null!;

    public string Checksum { get; set; } = null!;

    public long? FinishedAt { get; set; }

    public string MigrationName { get; set; } = null!;

    public string? Logs { get; set; }

    public DateTime? RolledBackAt { get; set; }

    public long StartedAt { get; set; }

    public int AppliedStepsCount { get; set; }
}
