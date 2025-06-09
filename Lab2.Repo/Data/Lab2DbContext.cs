using Microsoft.EntityFrameworkCore;
using Prn232.Lab2.Repo.Entities;
namespace Prn232.Lab2.Data;

public class Lab2DbContext : DbContext
{
    public Lab2DbContext(DbContextOptions<Lab2DbContext> options) : base(options)
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