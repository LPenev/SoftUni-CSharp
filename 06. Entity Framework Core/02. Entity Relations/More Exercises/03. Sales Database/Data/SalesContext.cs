using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data;

public class SalesContext : DbContext
{
    public SalesContext()
    {
        
    }

    SalesContext(DbContextOptions options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Sales;User=demo;Password=Demo1234");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(ct => 
        {
            ct.HasKey(ct => ct.CustomerId );
            
            ct.Property(ct => ct.Name)
                .HasMaxLength(100);

            ct.Property(ct => ct.Email)
                .HasMaxLength(80);

        });

        modelBuilder.Entity<Product>( pr => 
        {
            pr.HasKey(pr => pr.ProductId );

            pr.Property(pr => pr.Name)
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Sale>(s => 
        {
            s.HasKey(s => s.SaleId);

            s.HasOne(s => s.Customer)
                .WithMany(s => s.Sales)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Sale_Customers");

            s.HasOne(s => s.Product)
                .WithMany(s => s.Sales)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Sale_Products");

            s.HasOne(s => s.Store)
                .WithMany(s => s.Sales)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Sale_Stores");

        });

        modelBuilder.Entity<Store>(st =>
        {
            st.HasKey(st => st.StoreId);

            st.Property(st => st.Name)
                .HasMaxLength(80);
        });


        base.OnModelCreating(modelBuilder);
    }


}
