using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace quiz.Models;

public partial class OpentdbContext : DbContext
{
    public OpentdbContext()
    {
    }

    public OpentdbContext(DbContextOptions<OpentdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Difficulty> Difficulties { get; set; }

    public virtual DbSet<EfmigrationsLock> EfmigrationsLocks { get; set; }

    public virtual DbSet<IncorrectAnswer> IncorrectAnswers { get; set; }

    public virtual DbSet<PrismaMigration> PrismaMigrations { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=opentdb-app.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.ToTable("Answer");

            entity.HasIndex(e => e.Answer1, "Answer_answer_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer1).HasColumnName("answer");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.HasIndex(e => e.Name, "Category_name_key").IsUnique();

            entity.HasIndex(e => e.OpentdbId, "Category_opentdb_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OpentdbId).HasColumnName("opentdb_id");
        });

        modelBuilder.Entity<Difficulty>(entity =>
        {
            entity.ToTable("Difficulty");

            entity.HasIndex(e => e.Level, "Difficulty_level_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Level).HasColumnName("level");
        });

        modelBuilder.Entity<EfmigrationsLock>(entity =>
        {
            entity.ToTable("__EFMigrationsLock");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<IncorrectAnswer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_IncorrectAnswers");

            entity.HasIndex(e => new { e.A, e.B }, "_IncorrectAnswers_AB_unique").IsUnique();

            entity.HasIndex(e => e.B, "_IncorrectAnswers_B_index");

            entity.HasOne(d => d.ANavigation).WithMany().HasForeignKey(d => d.A);

            entity.HasOne(d => d.BNavigation).WithMany().HasForeignKey(d => d.B);
        });

        modelBuilder.Entity<PrismaMigration>(entity =>
        {
            entity.ToTable("_prisma_migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppliedStepsCount)
                .HasColumnType("INTEGER UNSIGNED")
                .HasColumnName("applied_steps_count");
            entity.Property(e => e.Checksum).HasColumnName("checksum");
            entity.Property(e => e.FinishedAt)
                .HasColumnType("DATETIME")
                .HasColumnName("finished_at");
            entity.Property(e => e.Logs).HasColumnName("logs");
            entity.Property(e => e.MigrationName).HasColumnName("migration_name");
            entity.Property(e => e.RolledBackAt)
                .HasColumnType("DATETIME")
                .HasColumnName("rolled_back_at");
            entity.Property(e => e.StartedAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("DATETIME")
                .HasColumnName("started_at");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CorrectAnswerId).HasColumnName("correct_answer_id");
            entity.Property(e => e.DifficultyId).HasColumnName("difficultyId");
            entity.Property(e => e.Question1).HasColumnName("question");
            entity.Property(e => e.TypeId).HasColumnName("typeId");

            entity.HasOne(d => d.Category).WithMany(p => p.Questions)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.CorrectAnswer).WithMany(p => p.Questions).HasForeignKey(d => d.CorrectAnswerId);

            entity.HasOne(d => d.Difficulty).WithMany(p => p.Questions)
                .HasForeignKey(d => d.DifficultyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Type).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("Type");

            entity.HasIndex(e => e.Type1, "Type_type_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type1).HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
