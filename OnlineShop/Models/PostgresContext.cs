using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Additional> Additionals { get; set; }

    public virtual DbSet<Bicycle> Bicycles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=2005");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Additional>(entity =>
        {
            entity
                .HasKey(e => e.Id);
            entity
                .ToTable("additional");
            entity.Property(e => e.Id)
           .HasColumnName("id")
           .ValueGeneratedOnAdd();  // автоинкрементируемыый

            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Staff)
                .HasMaxLength(255)
                .HasColumnName("staff");
        });

        modelBuilder.Entity<Bicycle>(entity =>
        {
            entity
                .HasKey(e => e.Id);
                entity.ToTable("bicycles");

            entity.Property(e => e.Id)
           .HasColumnName("id")
           .ValueGeneratedOnAdd();  // автоинкрементируемыый

            entity.Property(e => e.Countrycreator)
                .HasMaxLength(255)
                .HasColumnName("countrycreator");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Typeb)
                .HasMaxLength(255)
                .HasColumnName("typeb");
            entity.Property(e => e.Yearc).HasColumnName("yearc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
