namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetGuardianByIdQuery : IRequest<ResponseModel>
{
    public int GuardianId { get; set; }

    public GetGuardianByIdQuery(int guardianId)
    {
        GuardianId = guardianId;
    }
}