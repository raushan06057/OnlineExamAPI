namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetExamAttemptListQueryHandler : IRequestHandler<GetExamAttemptListQuery, ResponseModel>
{
    private readonly IExamAttemptRepository repository;

    public GetExamAttemptListQueryHandler(IExamAttemptRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetExamAttemptListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var examAttempts = await repository.GetAsync();
        responseModel.Success = true;
        responseModel.Data = examAttempts;
        return responseModel;
    }
}