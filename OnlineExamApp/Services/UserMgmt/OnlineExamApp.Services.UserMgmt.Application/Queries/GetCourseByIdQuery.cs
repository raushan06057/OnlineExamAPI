namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetCourseByIdQuery : IRequest<ResponseModel>
{
    public int CourseId { get; set; }

    public GetCourseByIdQuery(int courseId)
    {
        CourseId = courseId;
    }
}