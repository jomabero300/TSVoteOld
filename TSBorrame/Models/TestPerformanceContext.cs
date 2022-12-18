using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TSBorrame.Models;

public partial class TestPerformanceContext : DbContext
{
    public TestPerformanceContext()
    {
    }

    public TestPerformanceContext(DbContextOptions<TestPerformanceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Performance> Performances { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=MBEL\\SISTEMAS;Database=TestPerformance;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Performance>(entity =>
        {
            entity.ToTable("Performance");

            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
