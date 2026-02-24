namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateCourseEnrollmentCommand : IRequest<ResponseModel>
{
    public long StudentId { get; set; }   
    public long CourseId { get; set; }   
    public DateTime EnrollmentDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string? Grade { get; set; }
}
