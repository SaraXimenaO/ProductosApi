using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products.Domain.Entities;

namespace Products.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext() { }

    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
    {
    }

    public virtual DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder == null) { return; }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        modelBuilder.Entity<Product>()
                .HasKey(prop => prop.ProductId);
        modelBuilder.Entity<Product>()
                .Property(prop => prop.ProductId).ValueGeneratedOnAdd();

        modelBuilder.Entity<Product>()
            .Property(prop => prop.Price)
            .HasColumnType("decimal(18,2)");
        base.OnModelCreating(modelBuilder);
    }

}
