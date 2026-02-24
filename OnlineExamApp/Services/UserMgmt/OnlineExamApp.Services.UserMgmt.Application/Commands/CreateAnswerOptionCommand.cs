namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateAnswerOptionCommand : IRequest<ResponseModel>
{
    public string? Text { get; set; } // The text of the answer option
    public bool IsCorrect { get; set; } // Whether this is the correct answer
    public int QuestionId { get; set; } // Foreign key referencing the Question model
}
