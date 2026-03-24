namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetStudentExamResultsListQuery : IRequest<ResponseModel>
{
    public string StudentId { get; set; }
    public GetStudentExamResultsListQuery(string studentId)
    {
        StudentId = studentId;
    }
}
