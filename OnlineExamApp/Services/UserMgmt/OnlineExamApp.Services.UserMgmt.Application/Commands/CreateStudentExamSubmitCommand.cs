namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateStudentExamSubmitCommand : IRequest<ResponseModel>
{
    public string? CreatedBy { get; set; }
    public long ExamId { get; set; }
}
