using ConsoleApp29.Contexts;

namespace ConsoleApp29.Services;

public static class CRUDOperations
{
    public static void CreateStudent(string fullName, DateOnly birthDate, string email)
    {
        using (var context = new TestDbContext())
        {
            var student = new Models.Student
            {
                FullName = fullName,
                BirthDate = birthDate,
                Email = email
            };
            context.Students.Add(student);
            context.SaveChanges();
        }
    }
    public static void ReadStudents()
    {
        using (var context = new TestDbContext())
        {
            var students = context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.FullName}, Email: {student.Email}, BirthDate: {student.BirthDate}");
            }
        }
    }
    public static void UpdateStudent(int studentId, string newFullName, DateOnly newBirthDate, string newEmail)
    {
        using (var context = new TestDbContext())
        {
            var student = context.Students.Find(studentId);
            if (student != null)
            {
                student.FullName = newFullName;
                student.BirthDate = newBirthDate;
                student.Email = newEmail;
                context.SaveChanges();
            }
        }
    }
    public static void DeleteStudent(int studentId)
    {
        using (var context = new TestDbContext())
        {
            var student = context.Students.Find(studentId);
            if (student != null)
            {
                context.Students.Remove(student);
            }
            context.SaveChanges();
        }
    }
    public static void CreateTeacher(string fullName, string email, int departmentId)
    {
        using (var context = new TestDbContext())
        {
            var teacher = new Models.Teacher
            {
                FullName = fullName,
                Email = email,
                DepartmentId = departmentId
            };
            context.Departments.Find(departmentId)?.Teachers.Add(teacher);
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }
    }
    public static void ReadTeachers()
    {
        using (var context = new TestDbContext())
        {
            var teachers = context.Teachers.ToList();
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.Id}, Name: {teacher.FullName}, Email: {teacher.Email}, DepartmentId: {teacher.DepartmentId}");
            }
        }
    }
    public static void UpdateTeacher(int teacherId, string newFullName, string newEmail, int newDepartmentId)
    {
        using (var context = new TestDbContext())
        {
            var teacher = context.Teachers.Find(teacherId);
            if (teacher != null)
            {
                teacher.FullName = newFullName;
                teacher.Email = newEmail;
                teacher.DepartmentId = newDepartmentId;
            }
            context.SaveChanges();
        }
    }
    public static void DeleteTeacher(int teacherId)
    {
        using (var context = new TestDbContext())
        {
            var teacher = context.Teachers.Find(teacherId);
            if (teacher != null)
            {
                context.Teachers.Remove(teacher);
                context.SaveChanges();
            }
        }
    }
    public static void CreateDepartment(string name, string description)
    {
        using (var context = new TestDbContext())
        {
            var department = new Models.Department
            {
                Name = name,
                Description = description
            };
            context.Departments.Add(department);
            context.SaveChanges();
        }
    }
    public static void ReadDepartments()
    {
        using (var context = new TestDbContext())
        {
            var departments = context.Departments.ToList();
            foreach (var department in departments)
            {
                Console.WriteLine($"ID: {department.Id}, Name: {department.Name}, Description: {department.Description}");
            }
        }
    }
    public static void UpdateDepartment(int departmentId, string newName, string newDescription)
    {
        using (var context = new TestDbContext())
        {
            var department = context.Departments.Find(departmentId);
            if (department != null)
            {
                department.Name = newName;
                department.Description = newDescription;
            }
            context.SaveChanges();
        }
    }
    public static void DeleteDepartment(int departmentId)
    {
        using (var context = new TestDbContext())
        {
            var department = context.Departments.Find(departmentId);
            if (department != null)
            {
                context.Departments.Remove(department);
            }
            context.SaveChanges();
        }
    }
    public static void CreateCourse(string name, int credit, int departmentId, int teacherId)
    {
        using (var context = new TestDbContext())
        {
            var course = new Models.Course
            {
                Name = name,
                Credit = credit,
                DepartmentId = departmentId,
                TeacherId = teacherId
            };
            context.Departments.Find(departmentId)?.Courses.Add(course);
            context.Teachers.Find(teacherId)?.Courses.Add(course);
            context.Courses.Add(course);
            context.SaveChanges();
        }
    }
    public static void ReadCourses()
    {
        using (var context = new TestDbContext())
        {
            var courses = context.Courses.ToList();
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.Id}, Name: {course.Name}, Credit: {course.Credit}, DepartmentId: {course.DepartmentId}, TeacherId: {course.TeacherId}");
            }
        }
    }
    public static void UpdateCourse(int courseId, string newName, int newCredit)
    {
        using (var context = new TestDbContext())
        {
            var course = context.Courses.Find(courseId);
            if (course != null)
            {
                course.Name = newName;
                course.Credit = newCredit;
            }
            context.SaveChanges();
        }
    }
    public static void DeleteCourse(int courseId)
    {
        using (var context = new TestDbContext())
        {
            var course = context.Courses.Find(courseId);
            if (course != null)
            {
                context.Courses.Remove(course);
            }
            context.SaveChanges();
        }
    }
    public static void CreateEnrollment(int studentId, int courseId, DateTime enrollmentDate, int grade)
    {
        using (var context = new TestDbContext())
        {
            var enrollment = new Models.Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = enrollmentDate,
                Grade = grade
            };
            context.Students.Find(studentId)?.Enrollments.Add(enrollment);
            context.Courses.Find(courseId)?.Enrollments.Add(enrollment);
            context.Enrollments.Add(enrollment);
            context.SaveChanges();
        }
    }
    public static void ReadEnrollments()
    {
        using (var context = new TestDbContext())
        {
            var enrollments = context.Enrollments.ToList();
            foreach (var enrollment in enrollments)
            {
                Console.WriteLine($"StudentId: {enrollment.StudentId}, CourseId: {enrollment.CourseId}, EnrollmentDate: {enrollment.EnrollmentDate}, Grade: {enrollment.Grade}");
            }
        }
    }
    public static void UpdateEnrollment(int studentId, int courseId, DateTime newEnrollmentDate, int newGrade)
    {
        using (var context = new TestDbContext())
        {
            var enrollment = context.Enrollments.Find(studentId, courseId);
            if (enrollment != null)
            {
                enrollment.EnrollmentDate = newEnrollmentDate;
                enrollment.Grade = newGrade;
            }
            context.SaveChanges();
        }
    }
    public static void DeleteEnrollment(int studentId, int courseId)
    {
        using (var context = new TestDbContext())
        {
            var enrollment = context.Enrollments.Find(studentId, courseId);
            if (enrollment != null)
            {
                context.Enrollments.Remove(enrollment);
            }
            context.SaveChanges();
        }
    }
}
