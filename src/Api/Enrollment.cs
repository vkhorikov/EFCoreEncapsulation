namespace EFCoreEncapsulation.Api;

public class Enrollment
{
    public long Id { get; set; }
    public Grade Grade { get; set; }
    public Course Course { get; set; }
    public Student Student { get; set; }
}

public enum Grade
{
    A = 1,
    B = 2,
    C = 3,
    D = 4,
    F = 5
}
