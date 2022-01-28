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
        return _context.Students.Find(id);
    }
}
