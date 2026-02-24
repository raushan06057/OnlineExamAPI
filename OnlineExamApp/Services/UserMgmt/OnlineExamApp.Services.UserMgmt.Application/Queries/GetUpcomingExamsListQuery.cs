namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetUpcomingExamsListQuery:IRequest<ResponseModel>
{
    public string UserId { get; set; }
    public GetUpcomingExamsListQuery(string userId)
    {
        UserId = userId;
    }
}