namespace OnlineExamApp.Services.UserMgmt.Core.Entities;
[Table(CommonFields.StudentInfo)]
public class StudentInfoEntity : BasicInfoEntity
{
    public string Address { get; set; }

    // Navigation property for the Department or Major
    public long DepartmentId { get; set; }
    public OrgDepartmentEntity Department { get; set; }

    // Navigation property for the Course Enrollments
    public ICollection<CourseEnrollmentEntity> CourseEnrollments { get; set; }

    // Navigation property for the Guardian/Parent Information (if applicable)
    public long GuardianId { get; set; }
    public GuardianInfoEntity Guardian { get; set; }
    public ICollection<ExamAttemptEntity> ExamAttempts { get; set; }
    public string? UserId { get; set; }

    // Constructor to initialize collections (if needed)
    public StudentInfoEntity()
    {
        CourseEnrollments = new List<CourseEnrollmentEntity>();
        ExamAttempts = new List<ExamAttemptEntity>();
    }
}