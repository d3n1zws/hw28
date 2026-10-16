using ConsoleApp29.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp29.Contexts;

public class TestDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=task9;trusted_connection=true;TrustServerCertificate=true;");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TestDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
