using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulation.Api;

public class StudentRepository
{
    private readonly SchoolContext _context;

    public StudentRepository(SchoolContext context)
    {
        _context = context;
    }

    public Student GetByIdSplitQueries(long id)
    {
        return _context.Students
            .Include(x => x.Enrollments)
            .ThenInclude(x => x.Course)
            .Include(x => x.SportsEnrollments)
            .ThenInclude(x => x.Sports)
            .AsSplitQuery()
            .SingleOrDefault(x => x.Id == id);
    }

    public Student GetById(long id)
    {
        Student student = _context.Students.Find(id);

        if (student == null)
            return null;

        _context.Entry(student).Collection(x => x.Enrollments).Load();
        _context.Entry(student).Collection(x => x.SportsEnrollments).Load();

        return student;
    }

    public void Save(Student student)
    {
        // Use one of:

        _context.Students.Add(student);
        _context.Students.Update(student);
        _context.Students.Attach(student);
    }
}
