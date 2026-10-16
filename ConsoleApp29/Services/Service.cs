using ConsoleApp29.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp29.Services
{
    public static class Service
    {
        public static void ShowDepartmentWithTeacher()
        {
            var context = new TestDbContext();
            var departments = context.Departments
                .Include(d => d.Teachers)
                .ToList();
            foreach (var department in departments)
            {
                Console.WriteLine($"Department: {department.Name}");
                foreach (var teacher in department.Teachers)
                {
                    Console.WriteLine($"  Teacher: {teacher.FullName}");
                }
            }
        }
        public static void ShowDepartmentWithCourse()
        {
            var context = new TestDbContext();
            var departments = context.Departments
                .Include(d => d.Courses)
                .ThenInclude(c => c.Teacher)
                .ToList();
            foreach (var department in departments)
            {
                Console.WriteLine($"Department: {department.Name}");
                foreach (var course in department.Courses)
                {
                    Console.WriteLine($"  Course: {course.Name}");
                    Console.WriteLine($"    Teacher: {course.Teacher.FullName}");
                }
            }
        }
        public static void ShowCourseWithEnrollment()
        {
            var context = new TestDbContext();
            var courses = context.Courses
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .ToList();
            foreach (var course in courses)
            {
                Console.WriteLine($"Course: {course.Name}");
                foreach (var enrollment in course.Enrollments)
                {
                    Console.WriteLine($"  Student: {enrollment.Student.FullName}, Enrollment Date: {enrollment.EnrollmentDate}, Grade: {enrollment.Grade}");
                }
            }
        }
    }
}
