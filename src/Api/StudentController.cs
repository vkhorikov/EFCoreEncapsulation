using Microsoft.AspNetCore.Mvc;

namespace EFCoreEncapsulation.Api;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly StudentRepository _repository;
    private readonly SchoolContext _context;
    private readonly CourseRepository _courseRepository;

    public StudentController(StudentRepository repository, SchoolContext context, CourseRepository courseRepository)
    {
        _repository = repository;
        _context = context;
        _courseRepository = courseRepository;
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

    [HttpPost]
    public string Enroll(long studentId, long courseId, Grade grade)
    {
        Student student = _repository.GetById(studentId, true, false);
        if (student == null)
            return "Student not found";

        Course course = _courseRepository.GetById(courseId);
        if (course == null)
            return "Course not found";

        string result = student.EnrollIn(course, grade);

        _context.SaveChanges();

        return result;
    }

    [HttpPost]
    public string EditPersonalInfo(long studentId, string name)
    {
        Student student = _repository.GetById(studentId);
        if (student == null)
            return "Student not found";

        student.Name = name;

        _context.SaveChanges();

        return "OK";
    }
}
