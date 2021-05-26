using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DAL.Entities;
public class ApplicationContext : IdentityDbContext<Admin>
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database=Warehouses;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(AdminConfigure);
        modelBuilder.Entity<Client>(ClientConfigure);
        modelBuilder.Entity<Driver>(DriverConfigure);
        modelBuilder.Entity<Order>(OrderConfigure);
        modelBuilder.Entity<Product>(ProductConfigure);
        modelBuilder.Entity<Provider>(ProviderConfigure);
        modelBuilder.Entity<Warehouse>(WarehouseConfigure);
        modelBuilder.Entity<Stock>(StockConfigure);

        base.OnModelCreating(modelBuilder);
    }

    //Configurations
    public void AdminConfigure(EntityTypeBuilder<Admin> builder)
    {
        builder
            .HasKey(a => a.Email);
        builder
            .HasOne(w => w.Warehouse)
            .WithOne(a => a.Admin)
            .HasForeignKey<Warehouse>(a => a.AdminId);
    }
    public void ClientConfigure(EntityTypeBuilder<Client> builder)
    {

    }
    public void DriverConfigure(EntityTypeBuilder<Driver> builder)
    {
        builder
            .HasKey(d => d.Id);
        builder
            .HasOne(p => p.Warehouse)
            .WithMany(p => p.Drivers)
            .HasForeignKey(p => p.WarehouseId);
        builder
            .Property(d => d.Rating)
            .HasPrecision(18, 2);
        builder
            .Property(d => d.Wage)
            .HasPrecision(18, 2);
    }
    public void OrderConfigure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasOne(p => p.Client)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.ClientId);
        builder
            .HasOne(p => p.Product)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.ProductId);
        builder
            .HasOne(w => w.Warehouse)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.WarehouseId);
        builder
            .Property(o => o.Cost)
            .HasPrecision(18, 2);
    }
    public void ProductConfigure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasOne(p => p.Provider)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.ProviderId);
        builder
            .Property(p => p.Price)
            .HasPrecision(18, 2);
    }
    public void ProviderConfigure(EntityTypeBuilder<Provider> builder)
    {
        
    }
    public void WarehouseConfigure(EntityTypeBuilder<Warehouse> builder)
    {
        builder
            .HasMany(p => p.Products)
            .WithMany(w => w.Warehouses)
            .UsingEntity<Stock>(
                j => j
                    .HasOne(p => p.Product)
                    .WithMany(w => w.Stocks)
                    .HasForeignKey(p => p.ProductId),
                j => j
                    .HasOne(p => p.Warehouse)
                    .WithMany(w => w.Stocks)
                    .HasForeignKey(p => p.WarehouseId),
                j =>
                {
                    j.HasKey(t => new { t.WarehouseId, t.ProductId });
                    j.Property(p => p.SellPrice)
                         .HasPrecision(18, 2);
                    j.ToTable("Stock");
                }
            );
        /*
        builder
            .HasMany(o => o.Orders)
            .WithMany(w => w.Warehouses)
            .UsingEntity<WarehouseOrder>(
                j => j
                    .HasOne(p => p.Order)
                    .WithMany(w => w.WarehouseOrders)
                    .HasForeignKey(p => p.OrderId),
                j => j
                     .HasOne(p => p.Warehouse)
                     .WithMany(w => w.WarehouseOrders)
                     .HasForeignKey(w => w.WarehouseId),
                j =>
                {
                    j.HasKey(t => new { t.WarehouseId, t.OrderId });
                    j.ToTable("WarehouseOrders");
                }
            );
        builder
            .HasMany(p => p.Orders)
            .WithMany(w => w.Warehouses)
            .UsingEntity(t => t.ToTable("WarehouseOrders"));
        */

    }
    public void StockConfigure(EntityTypeBuilder<Stock> builder)
    {

    }
}
