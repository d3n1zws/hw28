# University Management System

A console-based University Management System developed using **C#, Entity Framework Core, and SQL Server**. The project demonstrates entity relationships, Fluent API configurations, CRUD operations, related data loading, delete behaviors, migrations, and entity state tracking.

## Features

- **Entity Relationships:** One-to-Many and Many-to-Many relationships.
- **Fluent API:** Entity configurations using `IEntityTypeConfiguration<TEntity>`.
- **Related Data Loading:** Using `Include()` and `ThenInclude()`.
- **DeleteBehavior:** Testing `Cascade`, `Restrict`, and `NoAction`.
- **EntityState:** Understanding `Added`, `Modified`, `Deleted`, `Unchanged`, and `Detached`.
- **ChangeTracker:** Monitoring entity states and tracked changes.
- **CRUD Operations:** Creating, reading, updating, and deleting records.
- **Database Migrations:** Managing database schema with EF Core migrations.
- **Error Handling:** Handling exceptions using `try-catch`.
- **Console Menu:** Performing operations through an interactive menu.
- **Seed Data:** Initializing the database with sample data.

## Technologies Used

- C#
- .NET
- Entity Framework Core
- SQL Server
- Fluent API
- LINQ

## Project Entities

The system consists of the following entities:

| Entity | Description |
|---|---|
| `Department` | Represents a university department. |
| `Teacher` | Represents a teacher belonging to a department. |
| `Course` | Represents a course taught by a teacher and offered by a department. |
| `Student` | Represents a university student. |
| `Enrollment` | Represents a student's enrollment in a course, including the enrollment date and grade. |

## Entity Relationships

- One `Department` can have multiple `Teachers`.
- One `Department` can offer multiple `Courses`.
- One `Teacher` can teach multiple `Courses`.
- One `Student` can enroll in multiple `Courses`.
- One `Course` can have multiple `Students`.
- The many-to-many relationship between `Student` and `Course` is implemented through the `Enrollment` entity.

The `Enrollment` entity stores additional information, including `EnrollmentDate` and `Grade`.

## Fluent API Configuration

Each entity has a separate configuration class implementing `IEntityTypeConfiguration<TEntity>`.

The configurations define:

- Primary keys and foreign keys.
- Required properties and maximum string lengths.
- Unique email constraints for students and teachers.
- Valid credit constraints for courses.
- Table and column names.
- Relationship configurations and delete behaviors.

## Include and ThenInclude

The project demonstrates how to retrieve related data using eager loading.

Examples include:

- Departments with their teachers.
- Departments with their courses and the teachers who teach them.
- Students with their enrollments and associated courses.
- Courses with their enrolled students.
- Student course details, including course names, enrollment dates, and grades.

## DeleteBehavior

The application tests different deletion scenarios:

- Deleting a department that has related teachers and courses.
- Deleting a course with existing enrollment records.
- Deleting a student with existing enrollments.
- Observing `Cascade`, `Restrict`, and `NoAction` behavior.
- Comparing EF Core's change tracking behavior with database-level cascade operations.

The selected delete behaviors are configured according to the relationships and business rules.

## EntityState and ChangeTracker

The application demonstrates the following entity states:

| EntityState | Description |
|---|---|
| `Added` | A new entity is marked for insertion. |
| `Modified` | An existing entity has been modified. |
| `Deleted` | An entity is marked for deletion. |
| `Unchanged` | An entity has no detected changes. |
| `Detached` | An entity is not tracked by the current `DbContext`. |

It also demonstrates how `SaveChanges()` affects entity states, how `Attach()` changes tracking behavior, and how `ChangeTracker.Entries()` can be used to inspect tracked entities.

## Console Menu

The application provides an interactive console menu with the following operations:

1. Add a Department.
2. Add a Teacher.
3. Add a Course.
4. Add a Student.
5. Enroll a Student in a Course.
6. Display Departments with related data.
7. Display Students and their Courses.
8. Display Students enrolled in a Course.
9. Update Student information.
10. Delete a Student.
11. Test DeleteBehavior scenarios.
12. Display ChangeTracker and EntityState information.
13. Exit.

## Getting Started

### Prerequisites

- .NET SDK
- SQL Server
- Entity Framework Core tools

### 1. Clone the repository

```bash
git clone <repository-url>
cd <project-directory>
```

### 2. Configure the database connection

Update the connection string in the project's configuration or `DbContext` to match your SQL Server instance.

### 3. Restore dependencies

```bash
dotnet restore
```

Install the required EF Core SQL Server and Design packages if they are not already included in the project.

### 4. Create the database

If migrations have not been created yet, run:

```bash
dotnet ef migrations add InitialCreate
```

Apply the migration:

```bash
dotnet ef database update
```

If the project contains existing migrations, apply them directly using `dotnet ef database update`.

### 5. Run the application

```bash
dotnet run
```

Follow the console menu to interact with the system.

## Learning Objectives

This project demonstrates practical knowledge of:

- Entity Framework Core and relational database design.
- One-to-many and many-to-many relationships.
- Fluent API and entity configuration.
- Eager loading with `Include()` and `ThenInclude()`.
- Referential integrity and delete behaviors.
- Entity state management and change tracking.
- Database migrations and schema management.
- CRUD operations and exception handling.

## Conclusion

The University Management System is designed to demonstrate how Entity Framework Core manages entities, relationships, database changes, and related data in a console application. It combines practical database operations with the core EF Core concepts required for understanding and building data-driven applications.
