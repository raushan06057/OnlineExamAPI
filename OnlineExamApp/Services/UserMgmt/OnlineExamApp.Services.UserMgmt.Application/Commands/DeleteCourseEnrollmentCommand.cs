namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteCourseEnrollmentCommand:IRequest<ResponseModel>
{
    public long Id { get; set; }
}
