using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection.Emit;

namespace Lab3.Domain.Data
{
    public class Lab3DbContext : DbContext
    {
        public Lab3DbContext(DbContextOptions<Lab3DbContext> options) : base(options)
        {
        }

        public DbSet<AccountMember> AccountMembers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<AccountMember>()
                .HasKey(a => a.MemberId);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);
        }
    }
}