using ConsoleApp29.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ConsoleApp29.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .HasMany(s => s.Enrollments)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(s => s.BirthDate)
            .HasColumnType("date");

        builder
            .Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(60);

        builder
            .Property(s => s.FullName)
            .IsRequired()
            .HasMaxLength(60);

        builder
            .HasAlternateKey(s => s.Email);

        builder
            .HasKey(s => s.Id);
    }
}
