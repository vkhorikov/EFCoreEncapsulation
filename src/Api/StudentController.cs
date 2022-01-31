using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulation.Api;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly StudentRepository _repository;
    private readonly SchoolContext _context;

    public StudentController(StudentRepository repository, SchoolContext context)
    {
        _repository = repository;
        _context = context;
    }

    [HttpGet("{id}")]
    public StudentDto Get(long id)
    {
        Student student = _repository.GetById(id);

        if (student == null)
            return null;

        return new StudentDto
        {
            StudentId = student.Id,
            Name = student.Name,
            Email = student.Email,
            Enrollments = student.Enrollments.Select(x => new EnrollmentDto
            {
                Course = x.Course.Name,
                Grade = x.Grade.ToString()
            }).ToList()
        };
    }

    [HttpPost]
    public void Register()
    {
        var student = new Student();

        // Assign student data from the incoming DTO

        _repository.Save(student);
    }
}
