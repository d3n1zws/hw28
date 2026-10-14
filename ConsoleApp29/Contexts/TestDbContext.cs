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
        base.OnModelCreating(modelBuilder);

        // enrollment
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentId, e.CourseId });

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId);


        // student
        modelBuilder.Entity<Student>()
            .HasMany(s => s.Courses)
            .WithMany(c => c.Students);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.Enrollments)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Student>()
            .Property(s => s.BirthDate)
            .HasColumnType("date");

        modelBuilder.Entity<Student>()
            .Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(60);

        modelBuilder.Entity<Student>()
            .Property(s => s.FullName)
            .IsRequired()
            .HasMaxLength(60);

        modelBuilder.Entity<Student>()
            .HasAlternateKey(s => s.Email);


        // course
        modelBuilder.Entity<Course>()
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Enrollments)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseId);

        modelBuilder.Entity<Course>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(60);

        modelBuilder.Entity<Course>()
            .Property(c => c.Credit)
            .IsRequired();

        modelBuilder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.TeacherId);

        modelBuilder.Entity<Course>()
            .HasOne(c => c.Department)
            .WithMany(d => d.Courses)
            .HasForeignKey(c => c.DepartmentId);

        modelBuilder.Entity<Course>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Course>()
            .HasAlternateKey(c => c.Name);

        //teacher
        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Courses)
            .WithOne(c => c.Teacher)
            .HasForeignKey(c => c.TeacherId);

        modelBuilder.Entity<Teacher>()
            .Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(60);

        modelBuilder.Entity<Teacher>()
            .HasAlternateKey(t => t.Email);

        modelBuilder.Entity<Teacher>()
            .Property(t => t.FullName)
            .IsRequired()
            .HasMaxLength(60);



        //department
        modelBuilder.Entity<Department>()
            .HasMany(d => d.Courses)
            .WithOne(c => c.Department)
            .HasForeignKey(c => c.DepartmentId);

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Teachers)
            .WithOne(t => t.Department)
            .HasForeignKey(t => t.DepartmentId);


    }
}
