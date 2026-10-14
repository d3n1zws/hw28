namespace ConsoleApp29.Models;

public class Teacher
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int DepartmentId { get; set; }
    public Department Department { get; set; } 
    public List<Course> Courses { get; set; } = new List<Course>();

}
