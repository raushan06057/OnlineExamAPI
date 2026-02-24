namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetAnswerListQueryHandler : IRequestHandler<GetAnswerListQuery, ResponseModel>
{
    private readonly IAnswerRepository repository;

    public GetAnswerListQueryHandler(IAnswerRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetAnswerListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var students = await repository.GetAsync();
        responseModel.Success = true;
        responseModel.Data = students;
        return responseModel;
    }
}