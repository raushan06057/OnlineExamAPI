namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class AnswerOptionEntity:BaseEntity
{
    public string? Text { get; set; } // The text of the answer option
    public bool IsCorrect { get; set; } // Whether this is the correct answer
    // Foreign key referencing the Question model
    [ForeignKey("Question")]
    public long QuestionId { get; set; }
    public QuestionEntity Question { get; set; } // The question this answer option belongs to
}
