namespace EFCoreEncapsulation.Api;

public class StudentDto
{
    public long StudentId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<EnrollmentDto> Enrollments { get; set; }
}

public class EnrollmentDto
{
    public string Grade { get; set; }
    public string Course { get; set; }
}
