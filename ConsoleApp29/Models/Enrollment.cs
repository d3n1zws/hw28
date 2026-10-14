using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp29.Models;

public class Enrollment
{
    [NotMapped]
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public int Grade { get; set; }
    public Student Student { get; set; }
    public Course Course { get; set; }
}
