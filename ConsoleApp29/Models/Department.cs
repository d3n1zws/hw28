namespace ConsoleApp29.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    public List<Course> Courses { get; set; } = new List<Course>();

}
