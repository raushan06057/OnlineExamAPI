namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetSubjectByIdQuery:IRequest<ResponseModel>
{
    public int SubjectId { get; set; }

    public GetSubjectByIdQuery(int subjectId)
    {
        SubjectId = subjectId;
    }
}
