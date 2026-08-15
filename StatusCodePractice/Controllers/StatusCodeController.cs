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
            Major = "Computer Engineering"

        },

        new Student
        {
            Id = 2,
            Name = "Jina2",
            Age = 20,
            Major = "Computer Engineering"
        },

         new Student
         {
             Id = 3,
             Name = "Jina3",
             Age = 20,
             Major = "Computer Engineering"
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