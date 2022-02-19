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
        return _repository.GetDto(id);
    }

    [HttpGet]
    public IReadOnlyList<StudentDto> GetAll()
    {
        return _repository.GetAll(".edu")
            .Select(MapToDto)
            .ToList();
    }

    private StudentDto MapToDto(Student student)
    {
        // Map student entity to StudentDto

        return null;
    }

    [HttpPost]
    public void Register()
    {
        var student = new Student();

        // Assign student data from the incoming DTO

        _repository.Save(student);
        _context.SaveChanges();
    }

    [HttpPost]
    public string Enroll(long studentId, long courseId, Grade grade)
    {
        Student student = _repository.GetById(studentId);
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
