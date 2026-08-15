using Microsoft.AspNetCore.Mvc;
using StatusCodePractice.Models;

namespace StatusCodePractice.Controllers;

[ApiController]
[Route("[controller]")]


public class StatusCodeController : ControllerBase
{
    
    private readonly List<Student> students = new List<Student>()
    {
        new Student
        {
            Id = 1,
            Name = "Jina1",
            Age = 20,
            Major = "Computer Engineering",
            
            Courses = new List<Course>{
            new Course {
            Id = 1,
            Name = "C# Programming",
            Units = 3
            
        },
             new Course
        {
                 Id = 2,
                 Name = "C# Programming",
                 Units = 4
        }
        }

        },

             new Student
        {
                    Id = 2,
                    Name = "Jina2",
                    Age = 20,
                    Major = "Computer Engineering",
                    
            Courses = new List<Course> {
                    new Course
                    {
                    Id = 3,
                    Name = "Algorithms",
                    Units = 3
        },
                new Course
        {
                     Id = 4,
                     Name = "Computer Architecture",
                     Units = 3
        }
                    
                    }
        },

         new Student
         {
             Id = 3,
             Name = "Jina3",
             Age = 20,
             Major = "Computer Engineering",
             
             Courses = new List<Course> {
             new Course {
             Id = 5,
             Name = "Operating Systems",
             Units = 3
         },
             new Course
             {
                 Id = 6,
                 Name = "Computer Architecture",
                 Units = 3
             }
         }
         }
    };

    [HttpGet("{id}")]

    public IActionResult GetStudents(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpGet("{studentId}/courses")]
    public IActionResult GetCourses(int studentId)
    {
        var student = students.FirstOrDefault(s => s.Id == studentId);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student.Courses);
    }
    
    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
        if (student == null)
        {
            return BadRequest("Student is null");
        }

        if (students.Any(s => s.Id == student.Id))
        {
            return Conflict();
        }

        students.Add(student);
        
        return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, student);
    }
}