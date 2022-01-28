namespace EFCoreEncapsulation.Api;

public class Student
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<SportsEnrollment> SportsEnrollments { get; set; }
}
