namespace EFCoreEncapsulation.Api;

public class Student
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<SportsEnrollment> SportsEnrollments { get; set; }

    public string EnrollIn(Course course, Grade grade)
    {
        if (Enrollments.Any(x => x.Course == course))
            return $"Already enrolled in course '{course.Name}'";

        var enrollment = new Enrollment
        {
            Course = course,
            Grade = grade,
            Student = this
        };
        Enrollments.Add(enrollment);

        return "OK";
    }
}
