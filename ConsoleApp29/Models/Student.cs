namespace ConsoleApp29.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
