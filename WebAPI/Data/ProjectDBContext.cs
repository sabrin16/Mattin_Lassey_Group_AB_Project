using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebAPI.Models;

namespace WebAPI.Data;

public class ProjectDBContext : DbContext
{
    public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options) { }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ContactPerson> ContactPeople { get; set; }
    public DbSet<CustomerContactPerson> CustomerContactPeople { get; set; }
    public DbSet<Employee> Employees{ get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<StatusType> StatusTypes { get; set; }
    public DbSet<Unit> Units{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>()
            .HasMany(p => p.Projects)
            .WithOne(c => c.Customer)
            .HasForeignKey(p => p.CusomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Employee>()
            .HasMany(p => p.Projects)
            .WithOne(e => e.Employee)
            .HasForeignKey(p => p.CusomerId);

        modelBuilder.Entity<Unit>()
            .HasMany(s => s.Services)
            .WithOne(u => u.Unit)
            .HasForeignKey(u => u.UnitId);

        modelBuilder.Entity<Currency>()
            .HasMany(s => s.Services)
            .WithOne(c => c.Currency)
            .HasForeignKey(c => c.CurrencyId);

        modelBuilder.Entity<Role>()
            .HasMany(e => e.Employees)
            .WithOne(r => r.Role)
            .HasForeignKey(r => r.RoleId);

        modelBuilder.Entity<StatusType>()
            .HasMany(p => p.Projects)
            .WithOne(s => s.StatusType)
            .HasForeignKey(s => s.StatusTypeId);

    }
}
