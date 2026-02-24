namespace OnlineExamApp.Services.UserMgmt.Application.Responses;

public class QuestionResponse
{
    public long Id { get; set; }
    public string? Text { get; set; } // The question text
    public QuestionType Type { get; set; } // Type of question (e.g., Multiple Choice, Essay)
    public IList<AnswerOptionEntity> AnswerOptions { get; set; } // Collection of answer options for multiple-choice questions
    [ForeignKey("Exam")]
    public long ExamId { get; set; } // Foreign key referencing the Exam model

    public ICollection<AnswerEntity> Answers { get; set; }
    public int Marks { get; set; }
}
