using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Entities.Orders;
using Core.Entities.Purchases;

namespace Infrastructure.Data;

public class MormorDagnysContext(DbContextOptions<MormorDagnysContext> options)
    : DbContext(options)
{

    public MormorDagnysContext() : this(new DbContextOptions<MormorDagnysContext>()) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<SupplierIngredient> SupplierIngredients => Set<SupplierIngredient>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Customer>().OwnsOne(c => c.DeliveryAddress);
        builder.Entity<Customer>().OwnsOne(c => c.InvoiceAddress);
        builder.Entity<Supplier>().OwnsOne(s => s.Address);

        builder.Entity<Order>()
            .HasMany(c => c.OrderItems)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Order>()
            .Property(c => c.OrderDate)
            .HasConversion(
                c => c.ToUniversalTime(),
                c => DateTime.SpecifyKind(c, DateTimeKind.Utc)
            );

        builder.Entity<OrderItem>().OwnsOne(c => c.ItemOrdered, i => i.WithOwner());

        builder.Entity<SupplierIngredient>(entity =>
        {
            entity.HasOne(si => si.Supplier)
                .WithMany(s => s.SupplierIngredients)
                .HasForeignKey(si => si.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(si => si.Ingredient)
                .WithMany(i => i.SupplierIngredients)
                .HasForeignKey(si => si.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}