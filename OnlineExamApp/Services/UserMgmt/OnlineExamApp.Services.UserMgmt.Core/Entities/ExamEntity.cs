namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class ExamEntity:BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DurationInMinutes {  get; set; }
    [ForeignKey("Organization")]
    public long OrganizationId { get; set; }
    public OrganizationEntity Organization { get; set; }
    public long DepartmentId { get; set; }
    [ForeignKey("Course")]
    public long CourseId { get; set; }
    [ForeignKey("Subject")]
    public long SubjectId { get; set; }
    public CourseEntity Course { get; set; }
    public SubjectEntity Subject { get; set; }
    public int TotalMarks { get; set; }
    public int PassingMarks { get; set; }
    public bool IsScheduled { get; set; } // Whether the exam is scheduled or on-demand
    public ICollection<QuestionEntity> Questions { get; set; } // Collection of questions in the exam
    public ICollection<ExamAttemptEntity> Attempts { get; set; } // Collection of attempts made by students
}
