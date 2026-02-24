namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetCourseEnrollmentByIdQuery : IRequest<ResponseModel>
{
    public int EnrollmentId { get; set; }

    public GetCourseEnrollmentByIdQuery(int enrollmentId)
    {
        EnrollmentId = enrollmentId;
    }
}