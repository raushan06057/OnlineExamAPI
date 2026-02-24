namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class QuestionEntity:BaseEntity
{
    public string? Text { get; set; } // The question text
    public QuestionType Type { get; set; } // Type of question (e.g., Multiple Choice, Essay)
    [ForeignKey("Exam")]
    public long ExamId { get; set; } // Foreign key referencing the Exam model
    public ExamEntity Exam { get; set; } // The exam this question belongs to
   
    public ICollection<AnswerEntity> Answers { get; set; }
    public ICollection<AnswerOptionEntity> AnswerOptions { get; set; }
    public int Marks { get; set; }
}
public enum QuestionType
{
    MultipleChoice=1,
    Essay=2,
    TrueFalse=3,
    FillInTheBlank=4
}