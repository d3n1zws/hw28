namespace ConsoleApp29.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Credit { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

}
