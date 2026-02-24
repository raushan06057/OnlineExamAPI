namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateAnswerCommand : IRequest<ResponseModel>
{
    public int QuestionId { get; set; } // Foreign key referencing the Question model
    public int AttemptId { get; set; } // Foreign key referencing the ExamAttempt model
    public string? Text { get; set; } // The text of the answer (for essay or fill-in-the-blank questions)
    public int? SelectedOptionId { get; set; } // Foreign key referencing the AnswerOption model (for multiple-choice questions)
}