using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
        modelBuilder.Entity<Supplier>().Property(e => e.Materials)
                                       .HasConversion(v => string.Join(",", v.Select(s => s.ToString())),
                                                      v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(s => (EMaterial)Enum.Parse(typeof(EMaterial), s))
                                           .ToList());

        modelBuilder.Entity<Supplier>().Property(e => e.SewingMachines)
                                       .HasConversion(v => string.Join(",", v.Select(s => s.ToString())),
                                                      v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(s => (ESewingMachine)Enum.Parse(typeof(ESewingMachine), s))
                                           .ToList());

        modelBuilder.Entity<Service>().Property(e => e.Materials)
                                       .HasConversion(v => string.Join(",", v.Select(s => s.ToString())),
                                                      v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(s => (EMaterial)Enum.Parse(typeof(EMaterial), s))
                                           .ToList());

        modelBuilder.Entity<Service>().Property(e => e.SewingMachines)
                                       .HasConversion(v => string.Join(",", v.Select(s => s.ToString())),
                                                      v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(s => (ESewingMachine)Enum.Parse(typeof(ESewingMachine), s))
                                           .ToList());

        modelBuilder.Entity<Service>().Property(p => p.Type)
                                         .HasConversion(v => v.ToString(),
                                                        v => (ERequestType)Enum.Parse(typeof(ERequestType), v));

       
        modelBuilder.Entity<ServiceOrder>().Ignore(serviceOrder => serviceOrder.Status);
        //modelBuilder.Entity<Contract>().Ignore(contract => contract.Status);
        modelBuilder.Entity<Payment>().Ignore(payment => payment.PaymentMethod);
    }
}
