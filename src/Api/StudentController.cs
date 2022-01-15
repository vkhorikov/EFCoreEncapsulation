using Microsoft.AspNetCore.Mvc;

namespace EFCoreEncapsulation.Api;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly SchoolContext _context;

    public StudentController(SchoolContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public StudentDto Get(long id)
    {
        Student student = _context.Students.Find(id);

        return new StudentDto
        {
            StudentId = student.Id,
            Name = student.Name,
            Email = student.Email
        };
    }
}
