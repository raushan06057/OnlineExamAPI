namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetUpcomingExamsListQueryHandler : IRequestHandler<GetUpcomingExamsListQuery, ResponseModel>
{
    private readonly IExamRepository repository;
    public GetUpcomingExamsListQueryHandler(IExamRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetUpcomingExamsListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var result = await repository.GetStudentExamSchedules(request.UserId);
        responseModel.Success = true;
        responseModel.Data = result;
        return responseModel;
    }
}
