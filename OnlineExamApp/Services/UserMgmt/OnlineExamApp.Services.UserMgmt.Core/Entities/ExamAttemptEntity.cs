namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class ExamAttemptEntity:BaseEntity
{
    public ExamEntity Exam { get; set; } // The exam being attempted
    [ForeignKey("Exam")]
    public long ExamId { get; set; } // Foreign key referencing the Exam model
    public StudentInfoEntity Student { get; set; } // The student making the attempt
    [ForeignKey("Student")]
    public long StudentId { get; set; } // Foreign key referencing the Student model
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Score { get; set; } // Score achieved in this attempt
    public ICollection<AnswerEntity> Answers { get; set; } // Collection of answers given by the student in this attempt
}
