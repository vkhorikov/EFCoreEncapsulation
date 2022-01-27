using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulation.Api;

public class StudentRepository
{
    private readonly SchoolContext _context;

    public StudentRepository(SchoolContext context)
    {
        _context = context;
    }

    public Student GetById(long id)
    {
        //Student student1 = _context.Students.Find(id);
        //Student student2 = _context.Students.Find(id);

        //Course course = _context.Courses.Find(1L);

        Student student1 = _context.Students
            .Include(x => x.Enrollments)
            .ThenInclude(x => x.Course)
            .SingleOrDefault(x => x.Id == id);

        Student student2 = _context.Students
            .Include(x => x.Enrollments)
            .ThenInclude(x => x.Course)
            .SingleOrDefault(x => x.Id == id);

        Course course = _context.Courses.SingleOrDefault(x => x.Id == 1L);

        return student1;
    }
}
