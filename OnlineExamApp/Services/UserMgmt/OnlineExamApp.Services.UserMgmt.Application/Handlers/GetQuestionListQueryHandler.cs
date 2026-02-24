namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetQuestionListQueryHandler : IRequestHandler<GetQuestionListQuery, ResponseModel>
{
    private readonly IQuestionRepository repository;

    public GetQuestionListQueryHandler(IQuestionRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        var questions = await repository.GetQuestionsAsync();

        responseModel.Success = true;
        responseModel.Data = questions;

        return responseModel;
    }
}