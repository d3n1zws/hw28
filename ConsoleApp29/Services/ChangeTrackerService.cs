using ConsoleApp29.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp29.Services;

public static class ChangeTrackerService
{
    public static void AddedStudent()
    {
        var context = new TestDbContext();
        var student = new Models.Student
        {
            FullName = "John Doe",
            BirthDate = new DateOnly(2000, 1, 1),
            Email = "john.doe@example.com"
        };
        context.Students.Add(student);
        Console.WriteLine(context.Entry(student).State);
        context.SaveChanges();
    }
    public static void ModifiedStudent(int studentId)
    {
        var context = new TestDbContext();
        var student = context.Students.Find(studentId);
        if (student != null)
        {
            student.FullName = "Jane Doe";
            Console.WriteLine(context.Entry(student).State);
            context.SaveChanges();
        }
    }
    public static void DeletedStudent(int studentId)
    {
        var context = new TestDbContext();
        var student = context.Students.Find(studentId);
        if (student != null)
        {
            context.Students.Remove(student);
            Console.WriteLine(context.Entry(student).State);
            context.SaveChanges();
        }
    }
    public static void DetachedStudent()
    {
        var context = new TestDbContext();
        var student = new Models.Student
        {
            FullName = "John Doe",
            BirthDate = new DateOnly(2000, 1, 1),
            Email = "john.doe@example.com"
        };
        Console.WriteLine(context.Entry(student).State);
    }
    public static void UnchangedStudent(int studentId)
    {
        var context = new TestDbContext();
        var student = context.Students.Find(studentId);
        if (student != null)
        {
            Console.WriteLine(context.Entry(student).State);
        }
    }
    public static void ShowChangeTrackerEntries()
    {
        var context = new TestDbContext();
        var entries = context.ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
        }
    }
}
