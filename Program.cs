using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public int CourseId { get; set; }
}

class Course
{
    public int CourseId { get; set; }
    public string? CourseName { get; set; }
}


class StudentManager
{
    private List<Student> students = new List<Student>();

    // Add Student
    public void AddStudent(Student student)
    {
        students.Add(student);

    }

    
    public void ListStudents()
    {
        Console.WriteLine("\n--- Students ---");

        foreach (Student student in students)
        {
            Console.WriteLine(
                $"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course ID: {student.CourseId}"
            );
        }
    }

    
    public void UpdateStudent(int id, string name, int age, int courseId)
    {
        Student student = students.FirstOrDefault(s => s.Id == id);

        if (student != null)
        {
            student.Name = name;
            student.Age = age;
            student.CourseId = courseId;

            Console.WriteLine("Student updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }


    public void DeleteStudent(int id)
    {
        Student student = students.FirstOrDefault(s => s.Id == id);

        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }


    public void StudentsAboveAge(int age)
    {
        var result = students.Where(s => s.Age > age);

        Console.WriteLine($"\nStudents above age {age}:");

        foreach (Student student in result)
        {
            Console.WriteLine($"{student.Name} - {student.Age}");
        }
    }

    
    public void StudentsByCourse(int courseId)
    {
        var result = students.Where(s => s.CourseId == courseId);

        Console.WriteLine($"\nStudents in Course ID {courseId}:");

        foreach (Student student in result)
        {
            Console.WriteLine(student.Name);
        }
    }
}



class CourseManager
{
    private List<Course> courses = new List<Course>();

    
    public void AddCourse(Course course)
    {
        courses.Add(course);
        Console.WriteLine("Course added successfully.");
    }

    
    public void ListCourses()
    {
        Console.WriteLine("\n--- Courses ---");

        foreach (Course course in courses)
        {
            Console.WriteLine(
                $"Course ID: {course.CourseId}, Course Name: {course.CourseName}"
            );
        }
    }
}



class Program
{
    static void Main()
    {
        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();


        
        courseManager.AddCourse(new Course
        {
            CourseId = 101,
            CourseName = "Computer Science"
        });

        courseManager.AddCourse(new Course
        {
            CourseId = 102,
            CourseName = "Data Science"
        });

        courseManager.AddCourse(new Course
        {
            CourseId = 103,
            CourseName = "Web Development"
        });


    
        courseManager.ListCourses();


    
        studentManager.AddStudent(new Student
        {
            Id = 1,
            Name = "Misna",
            Age = 22,
            CourseId = 101
        });

        studentManager.AddStudent(new Student
        {
            Id = 2,
            Name = "Aisha",
            Age = 20,
            CourseId = 102
        });

        studentManager.AddStudent(new Student
        {
            Id = 3,
            Name = "Sara",
            Age = 23,
            CourseId = 101
        });


        
        studentManager.ListStudents();


        
        Console.WriteLine("\n--- Updating Student ---");

        studentManager.UpdateStudent(
            2,
            "Aisha Khan",
            21,
            103
        );

        studentManager.ListStudents();


    
        Console.WriteLine("\n--- Deleting Student ---");

        studentManager.DeleteStudent(3);

        studentManager.ListStudents();


        
        studentManager.StudentsAboveAge(20);


        studentManager.StudentsByCourse(101);
    }
}