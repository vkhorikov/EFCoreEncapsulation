namespace EFCoreEncapsulation.Api;

public class Enrollment
{
    public long Id { get; set; }
    public Grade Grade { get; }
    public virtual Course Course { get; }
    public virtual Student Student { get; }

    protected Enrollment()
    {
    }

    public Enrollment(Course course, Student student, Grade grade)
        : this()
    {
        Course = course;
        Student = student;
        Grade = grade;
    }
}

public enum Grade
{
    A = 1,
    B = 2,
    C = 3,
    D = 4,
    F = 5
}
