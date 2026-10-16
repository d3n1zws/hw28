

using ConsoleApp29.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ConsoleApp29.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder
            .HasMany(t => t.Courses)
            .WithOne(c => c.Teacher)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(t => t.Department)
            .WithMany(d => d.Teachers)
            .HasForeignKey(t => t.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(60);

        builder
            .HasAlternateKey(t => t.Email);

        builder
            .Property(t => t.FullName)
            .IsRequired()
            .HasMaxLength(60);

        builder
            .HasKey(t => t.Id);
    }
}
