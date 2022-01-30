using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulation.Api;

public sealed class SchoolContext : DbContext
{
    private readonly string _connectionString;
    private readonly bool _useConsoleLogger;

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    
    public SchoolContext(string connectionString, bool useConsoleLogger)
    {
        _connectionString = connectionString;
        _useConsoleLogger = useConsoleLogger;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);

        if (_useConsoleLogger)
        {
            optionsBuilder
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging();
        }
        else
        {
            optionsBuilder
                .UseLoggerFactory(CreateEmptyLoggerFactory());
        }
    }

    private static ILoggerFactory CreateEmptyLoggerFactory()
    {
        return LoggerFactory.Create(builder => builder
            .AddFilter((_, _) => false));
    }

    private static ILoggerFactory CreateLoggerFactory()
    {
        return LoggerFactory.Create(builder => builder
            .AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
            .AddConsole());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(x =>
        {
            x.ToTable("Student").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("StudentID");
            x.Property(p => p.Email);
            x.Property(p => p.Name);
            x.HasMany(p => p.Enrollments).WithOne(p => p.Student);
            //x.Navigation(p => p.Enrollments).AutoInclude();
            x.HasMany(p => p.SportsEnrollments).WithOne(p => p.Student);
            //x.Navigation(p => p.SportsEnrollments).AutoInclude();
        });
        modelBuilder.Entity<Course>(x =>
        {
            x.ToTable("Course").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("CourseID");
            x.Property(p => p.Name);
        });
        modelBuilder.Entity<Enrollment>(x =>
        {
            x.ToTable("Enrollment").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("EnrollmentID");
            x.HasOne(p => p.Student).WithMany(p => p.Enrollments);
            x.HasOne(p => p.Course).WithMany();
            x.Navigation(p => p.Course).AutoInclude();
            x.Property(p => p.Grade);
        });
        modelBuilder.Entity<Sports>(x =>
        {
            x.ToTable("Sports").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("SportsID");
            x.Property(p => p.Name);
        });
        modelBuilder.Entity<SportsEnrollment>(x =>
        {
            x.ToTable("SportsEnrollment").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("SportsEnrollmentID");
            x.HasOne(p => p.Student).WithMany(p => p.SportsEnrollments);
            x.HasOne(p => p.Sports).WithMany();
            x.Property(p => p.Grade);
            x.Navigation(p => p.Sports).AutoInclude();
        });
    }
}
