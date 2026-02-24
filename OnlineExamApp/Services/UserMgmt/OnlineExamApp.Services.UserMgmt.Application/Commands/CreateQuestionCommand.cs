namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateQuestionCommand : IRequest<ResponseModel>
{
    public string? Text { get; set; } // The question text
    public QuestionType Type { get; set; } // Type of question (e.g., Multiple Choice, Essay)
    public List<AnswerOptionModel> AnswerOptions { get; set; } // Collection of answer options for multiple-choice questions
    public long ExamId { get; set; } // Foreign key referencing the Exam model
    public int Marks { get; set; }
}

public class AnswerOptionModel
{
    public string? Text { get; set; }
    public bool IsCorrect { get; set; }
}