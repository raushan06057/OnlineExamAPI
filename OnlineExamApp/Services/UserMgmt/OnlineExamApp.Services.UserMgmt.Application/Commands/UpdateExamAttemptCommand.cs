namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class UpdateExamAttemptCommand : IRequest<ResponseModel>
{
    public long Id {  get; set; }
    public int ExamId { get; set; }
    public int StudentId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Score { get; set; }
}