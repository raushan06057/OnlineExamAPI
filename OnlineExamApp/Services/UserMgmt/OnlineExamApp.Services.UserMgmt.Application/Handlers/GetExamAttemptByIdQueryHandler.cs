namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetExamAttemptByIdQueryHandler : IRequestHandler<GetExamAttemptByIdQuery, ResponseModel>
{
    private readonly IExamAttemptRepository repository;

    public GetExamAttemptByIdQueryHandler(IExamAttemptRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetExamAttemptByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        var examAttempt = await repository.GetAsync(request.Id);

        if (examAttempt != null)
        {
            responseModel.Success = true;
            responseModel.Data = examAttempt;
        }
        else
        {
            responseModel.Success = false;
            responseModel.Message = "Exam attempt not found";
        }

        return responseModel;
    }
}