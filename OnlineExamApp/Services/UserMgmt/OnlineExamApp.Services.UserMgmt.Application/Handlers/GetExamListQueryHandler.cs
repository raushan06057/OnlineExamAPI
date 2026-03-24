namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetExamListQueryHandler : IRequestHandler<GetExamListQuery, ResponseModel>
{
    private readonly IExamRepository repository;

    public GetExamListQueryHandler(IExamRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetExamListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        var exams = await repository.GetExamsAsync(request.Username);

        responseModel.Success = true;
        responseModel.Data = exams;

        return responseModel;
    }
}