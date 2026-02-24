namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateSubjectCommand:IRequest<ResponseModel>
{
    public string? Name { get; set; }
    public long CourseId { get; set; }
    public long DepartmentId { get; set; }
}