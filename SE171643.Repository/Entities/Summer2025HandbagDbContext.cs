using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SE171643.Repository.Entities;

public partial class Summer2025HandbagDbContext : DbContext
{
    public Summer2025HandbagDbContext()
    {
    }

    public Summer2025HandbagDbContext(DbContextOptions<Summer2025HandbagDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Handbag> Handbags { get; set; }

    public virtual DbSet<SystemAccount> SystemAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brand__DAD4F3BE8D165DD8");

            entity.ToTable("Brand");

            entity.Property(e => e.BrandId)
                .ValueGeneratedNever()
                .HasColumnName("BrandID");
            entity.Property(e => e.BrandName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Handbag>(entity =>
        {
            entity.HasKey(e => e.HandbagId).HasName("PK__Handbag__785BD69FD126B413");

            entity.ToTable("Handbag");

            entity.Property(e => e.HandbagId)
                .ValueGeneratedNever()
                .HasColumnName("HandbagID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Material)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModelName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Brand).WithMany(p => p.Handbags)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_handbag_brand");
        });

        modelBuilder.Entity<SystemAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__SystemAc__349DA58617998D16");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

    }
}
