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
}