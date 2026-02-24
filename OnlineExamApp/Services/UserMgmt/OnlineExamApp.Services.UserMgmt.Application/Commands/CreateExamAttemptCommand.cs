namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateExamAttemptCommand : IRequest<ResponseModel>
{
    public int ExamId { get; set; }
    public int StudentId { get; set; } 
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Score { get; set; }
}