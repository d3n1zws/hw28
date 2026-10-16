using ConsoleApp29.Services;

static int ReadInt(string prompt)
{
    Console.Write(prompt);
    return int.TryParse(Console.ReadLine(), out var v) ? v : -1;
}

static string ReadString(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine() ?? string.Empty;
}

static DateOnly ReadDateOnly(string prompt)
{
    Console.Write(prompt);
    return DateOnly.TryParse(Console.ReadLine(), out var d) ? d : new DateOnly(2000, 1, 1);
}

static DateTime ReadDateTime(string prompt)
{
    Console.Write(prompt);
    return DateTime.TryParse(Console.ReadLine(), out var d) ? d : DateTime.Now;
}

while (true)
{
    Console.Clear();
    Console.WriteLine("=== School Console Menu ===");
    Console.WriteLine("0. Exit");
    Console.WriteLine("--- Service queries ---");
    Console.WriteLine("1. Show departments with teachers");
    Console.WriteLine("2. Show departments with courses and teachers");
    Console.WriteLine("3. Show courses with enrollments");
    Console.WriteLine("--- Students ---");
    Console.WriteLine("10. Read students");
    Console.WriteLine("11. Create student");
    Console.WriteLine("12. Update student");
    Console.WriteLine("13. Delete student");
    Console.WriteLine("--- Teachers ---");
    Console.WriteLine("20. Read teachers");
    Console.WriteLine("21. Create teacher");
    Console.WriteLine("22. Update teacher");
    Console.WriteLine("23. Delete teacher");
    Console.WriteLine("--- Departments ---");
    Console.WriteLine("30. Read departments");
    Console.WriteLine("31. Create department");
    Console.WriteLine("32. Update department");
    Console.WriteLine("33. Delete department");
    Console.WriteLine("--- Courses ---");
    Console.WriteLine("40. Read courses");
    Console.WriteLine("41. Create course");
    Console.WriteLine("42. Update course");
    Console.WriteLine("43. Delete course");
    Console.WriteLine("--- Enrollments ---");
    Console.WriteLine("50. Read enrollments");
    Console.WriteLine("51. Create enrollment");
    Console.WriteLine("52. Update enrollment");
    Console.WriteLine("53. Delete enrollment");
    Console.WriteLine("--- ChangeTracker / Entity states ---");
    Console.WriteLine("60. Show change tracker entries");
    Console.WriteLine("61. ChangeTracker: add demo student (Added)");
    Console.WriteLine("62. ChangeTracker: modify student (Modified)");
    Console.WriteLine("63. ChangeTracker: delete student (Deleted)");
    Console.WriteLine("64. ChangeTracker: detached student (Detached)");
    Console.WriteLine("65. ChangeTracker: show unchanged student state (Unchanged)");

    var opt = ReadInt("Select an option: ");
    Console.WriteLine();

    switch (opt)
    {
        case 0: return;
        case 1: Service.ShowDepartmentWithTeacher(); break;
        case 2: Service.ShowDepartmentWithCourse(); break;
        case 3: Service.ShowCourseWithEnrollment(); break;

        case 10: CRUDOperations.ReadStudents(); break;
        case 11:
        {
            var name = ReadString("Full name: ");
            var bd = ReadDateOnly("Birth date (yyyy-MM-dd): ");
            var email = ReadString("Email: ");
            CRUDOperations.CreateStudent(name, bd, email);
            Console.WriteLine("Student created.");
            break;
        }
        case 12:
        {
            var id = ReadInt("Student id: ");
            var name = ReadString("New full name: ");
            var bd = ReadDateOnly("New birth date (yyyy-MM-dd): ");
            var email = ReadString("New email: ");
            CRUDOperations.UpdateStudent(id, name, bd, email);
            Console.WriteLine("Update attempted.");
            break;
        }
        case 13:
        {
            var id = ReadInt("Student id to delete: ");
            CRUDOperations.DeleteStudent(id);
            Console.WriteLine("Delete attempted.");
            break;
        }

        case 20: CRUDOperations.ReadTeachers(); break;
        case 21:
        {
            var name = ReadString("Full name: ");
            var email = ReadString("Email: ");
            var deptId = ReadInt("Department id: ");
            CRUDOperations.CreateTeacher(name, email, deptId);
            Console.WriteLine("Teacher created.");
            break;
        }
        case 22:
        {
            var id = ReadInt("Teacher id: ");
            var name = ReadString("New full name: ");
            var email = ReadString("New email: ");
            var deptId = ReadInt("New department id: ");
            CRUDOperations.UpdateTeacher(id, name, email, deptId);
            Console.WriteLine("Update attempted.");
            break;
        }
        case 23:
        {
            var id = ReadInt("Teacher id to delete: ");
            CRUDOperations.DeleteTeacher(id);
            Console.WriteLine("Delete attempted.");
            break;
        }

        case 30: CRUDOperations.ReadDepartments(); break;
        case 31:
        {
            var name = ReadString("Department name: ");
            var desc = ReadString("Description: ");
            CRUDOperations.CreateDepartment(name, desc);
            Console.WriteLine("Department created.");
            break;
        }
        case 32:
        {
            var id = ReadInt("Department id: ");
            var name = ReadString("New name: ");
            var desc = ReadString("New description: ");
            CRUDOperations.UpdateDepartment(id, name, desc);
            Console.WriteLine("Update attempted.");
            break;
        }
        case 33:
        {
            var id = ReadInt("Department id to delete: ");
            CRUDOperations.DeleteDepartment(id);
            Console.WriteLine("Delete attempted.");
            break;
        }

        case 40: CRUDOperations.ReadCourses(); break;
        case 41:
        {
            var name = ReadString("Course name: ");
            var credit = ReadInt("Credit: ");
            var deptId = ReadInt("Department id: ");
            var teacherId = ReadInt("Teacher id: ");
            CRUDOperations.CreateCourse(name, credit, deptId, teacherId);
            Console.WriteLine("Course created.");
            break;
        }
        case 42:
        {
            var id = ReadInt("Course id: ");
            var name = ReadString("New name: ");
            var credit = ReadInt("New credit: ");
            CRUDOperations.UpdateCourse(id, name, credit);
            Console.WriteLine("Update attempted.");
            break;
        }
        case 43:
        {
            var id = ReadInt("Course id to delete: ");
            CRUDOperations.DeleteCourse(id);
            Console.WriteLine("Delete attempted.");
            break;
        }

        case 50: CRUDOperations.ReadEnrollments(); break;
        case 51:
        {
            var studentId = ReadInt("Student id: ");
            var courseId = ReadInt("Course id: ");
            var dt = ReadDateTime("Enrollment date (yyyy-MM-dd): ");
            var grade = ReadInt("Grade: ");
            CRUDOperations.CreateEnrollment(studentId, courseId, dt, grade);
            Console.WriteLine("Enrollment created.");
            break;
        }
        case 52:
        {
            var studentId = ReadInt("Student id: ");
            var courseId = ReadInt("Course id: ");
            var dt = ReadDateTime("New enrollment date (yyyy-MM-dd): ");
            var grade = ReadInt("New grade: ");
            CRUDOperations.UpdateEnrollment(studentId, courseId, dt, grade);
            Console.WriteLine("Update attempted.");
            break;
        }
        case 53:
        {
            var studentId = ReadInt("Student id: ");
            var courseId = ReadInt("Course id: ");
            CRUDOperations.DeleteEnrollment(studentId, courseId);
            Console.WriteLine("Delete attempted.");
            break;
        }

        case 60: ChangeTrackerService.ShowChangeTrackerEntries(); break;
        case 61: ChangeTrackerService.AddedStudent(); Console.WriteLine("Added demo student (not persisted by caller beyond service)."); break;
        case 62:
        {
            var id = ReadInt("Student id to mark modified: ");
            ChangeTrackerService.ModifiedStudent(id);
            Console.WriteLine("Modify attempted.");
            break;
        }
        case 63:
        {
            var id = ReadInt("Student id to mark deleted: ");
            ChangeTrackerService.DeletedStudent(id);
            Console.WriteLine("Delete attempted.");
            break;
        }
        case 64: ChangeTrackerService.DetachedStudent(); Console.WriteLine("Detached demo executed."); break;
        case 65:
        {
            var id = ReadInt("Student id to show unchanged state: ");
            ChangeTrackerService.UnchangedStudent(id);
            break;
        }

        default: Console.WriteLine("Unknown option."); break;
    }

    Console.WriteLine();
    Console.WriteLine("Operation finished. Press Enter to continue...");
    Console.ReadLine();
}
