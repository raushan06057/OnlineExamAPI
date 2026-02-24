namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateStudentQuestionAttemptCommand : IRequest<ResponseModel>
{
    //public long Id { get; set; }
    public long QuestionId {  get; set; }
    public string? Text { get; set; } // The question text
    public QuestionType Type { get; set; } // Type of question (e.g., Multiple Choice, Essay)
    public List<UpdateAnswerOptionModel> AnswerOptions { get; set; } // Collection of answer options for multiple-choice questions
    public long ExamId { get; set; } // Foreign key referencing the Exam model
    public int Marks { get; set; }
    public string? CreatedBy { get; set; }
}