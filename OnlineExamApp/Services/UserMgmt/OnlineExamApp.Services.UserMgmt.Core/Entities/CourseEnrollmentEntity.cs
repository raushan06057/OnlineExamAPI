namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

[Table(CommonFields.CourseEnrollments)]
public class CourseEnrollmentEntity:BaseEntity
{
    [ForeignKey("Student")]
    public long StudentId { get; set; }
    public StudentInfoEntity Student { get; set; }
    [ForeignKey("Course")]
    public long CourseId { get; set; }
    public CourseEntity Course { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string? Grade { get; set; }
}