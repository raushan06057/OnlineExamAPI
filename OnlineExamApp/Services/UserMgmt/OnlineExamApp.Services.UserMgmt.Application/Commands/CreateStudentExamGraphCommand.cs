namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateStudentExamGraphCommand:IRequest<ResponseModel>
{
    public string? CreatedBy { get; set; }
    public long ExamId { get; set; }
}
