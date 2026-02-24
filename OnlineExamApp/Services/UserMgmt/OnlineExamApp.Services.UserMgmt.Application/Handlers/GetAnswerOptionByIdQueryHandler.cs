namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetAnswerOptionByIdQueryHandler : IRequestHandler<GetAnswerOptionByIdQuery, ResponseModel>
{
    private readonly IAnswerOptionRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetAnswerOptionByIdQueryHandler> logger;

    public GetAnswerOptionByIdQueryHandler(
        IAnswerOptionRepository repository,
        IMapper mapper,
        ILogger<GetAnswerOptionByIdQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(GetAnswerOptionByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        try
        {
            var answerOption = await repository.GetAsync(request.Id);

            if (answerOption == null)
            {
                responseModel.Success = false;
                responseModel.Data = "Answer option not found.";
                return responseModel;
            }

            responseModel.Success = true;
            responseModel.Data = answerOption;

            return responseModel;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while retrieving answer option by id.");
            responseModel.Success = false;
            responseModel.Data = "An error occurred.";
            return responseModel;
        }
    }
}
