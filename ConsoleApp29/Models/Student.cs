namespace ConsoleApp29.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; }
    public DateOnly BirthDate { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
