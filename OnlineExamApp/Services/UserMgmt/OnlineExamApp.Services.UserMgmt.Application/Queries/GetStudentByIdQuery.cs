namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetStudentByIdQuery : IRequest<ResponseModel>
{
    public int StudentId { get; set; }

    public GetStudentByIdQuery(int studentId)
    {
        StudentId = studentId;
    }
}