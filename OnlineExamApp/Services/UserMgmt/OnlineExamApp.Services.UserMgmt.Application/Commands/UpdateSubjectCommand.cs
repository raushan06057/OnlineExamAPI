namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class UpdateSubjectCommand:IRequest<ResponseModel>
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public long CourseId { get; set; }
    public long DepartmentId { get; set; }
}