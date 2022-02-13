using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulation.Api;

public class StudentRepository : Repository<Student>
{
    public StudentRepository(SchoolContext context)
        : base(context)
    {
    }

    //public Student GetByIdSplitQueries(long id)
    //{
    //    return _context.Students
    //        .Include(x => x.Enrollments)
    //        .ThenInclude(x => x.Course)
    //        .Include(x => x.SportsEnrollments)
    //        .ThenInclude(x => x.Sports)
    //        .AsSplitQuery()
    //        .SingleOrDefault(x => x.Id == id);
    //}

    public StudentDto GetDto(long id)
    {
        Student student = _context.Students.Find(id);

        if (student == null)
            return null;

        List<EnrollmentData> enrollments = _context.Set<EnrollmentData>()
            .FromSqlInterpolated($@"
                SELECT e.StudentID, e.Grade, c.Name Course
                FROM dbo.Enrollment e
                INNER JOIN dbo.Course c ON e.CourseID = c.CourseID
                WHERE e.StudentID = {id}")
            .ToList();

        return new StudentDto
        {
            StudentId = id,
            Name = student.Name,
            Email = student.Email,
            Enrollments = enrollments.Select(x => new EnrollmentDto
            {
                Course = x.Course,
                Grade = ((Grade)x.Grade).ToString()
            }).ToList()
        };
    }

    public override Student GetById(long id)
    {
        Student student = _context.Students.Find(id);

        if (student == null)
            return null;

        _context.Entry(student).Collection(x => x.Enrollments).Load();
        _context.Entry(student).Collection(x => x.SportsEnrollments).Load();

        return student;
    }

    public override void Save(Student student)
    {
        // Use one of:

        _context.Students.Add(student);
        _context.Students.Update(student);
        _context.Students.Attach(student);
    }
}

public class CourseRepository : Repository<Course>
{
    public CourseRepository(SchoolContext context)
        : base(context)
    {
    }
}

public abstract class Repository<T>
    where T : class
//    where T : Entity
{
    protected readonly SchoolContext _context;

    protected Repository(SchoolContext context)
    {
        _context = context;
    }

    public virtual T GetById(long id)
    {
        return _context.Set<T>().Find(id);
    }

    public virtual void Save(T entity)
    {
        _context.Set<T>().Add(entity);
    }
}
