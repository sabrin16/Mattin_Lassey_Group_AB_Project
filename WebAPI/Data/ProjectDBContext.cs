using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebAPI.Models;

namespace WebAPI.Data;

public class ProjectDBContext : DbContext
{

    public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
            : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ContactPerson> ContactPeople { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Service> Services { get; set; }


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

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.ContactPeople)
            .WithMany(cp => cp.Customers)
            .UsingEntity(k => k.ToTable("ContactPersonCustomer"));

    }
}
