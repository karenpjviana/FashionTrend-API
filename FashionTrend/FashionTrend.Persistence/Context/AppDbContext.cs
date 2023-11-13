using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
     
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceOrder> ServiceOrders { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supplier>().Ignore(supplier => supplier.Materials); 
        modelBuilder.Entity<Supplier>().Ignore(supplier => supplier.SewingMachines);
        modelBuilder.Entity<Service>().Ignore(service => service.Materials);
        modelBuilder.Entity<Service>().Ignore(service => service.SewingMachines);
        modelBuilder.Entity<Service>().Ignore(service => service.Type);
        modelBuilder.Entity<ServiceOrder>().Ignore(serviceOrder => serviceOrder.Status);
        modelBuilder.Entity<Contract>().Ignore(contract => contract.Status);
        modelBuilder.Entity<Payment>().Ignore(payment => payment.PaymentMethod);
    }
}
