namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetAnswerOptionListQueryHandler : IRequestHandler<GetAnswerOptionListQuery, ResponseModel>
{
    private readonly IAnswerOptionRepository repository;

    public GetAnswerOptionListQueryHandler(IAnswerOptionRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetAnswerOptionListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        var answerOptions = await repository.GetAsync(request.QuestionId);

        responseModel.Success = true;
        responseModel.Data = answerOptions;

        return responseModel;
    }
}