namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateAnswerOptionCommandHandler : IRequestHandler<CreateAnswerOptionCommand, ResponseModel>
{
    private readonly IAnswerOptionRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateAnswerOptionCommandHandler> logger;

    public CreateAnswerOptionCommandHandler(
        IAnswerOptionRepository repository,
        IMapper mapper,
        ILogger<CreateAnswerOptionCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(CreateAnswerOptionCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Check if the question exists
        var questionExists = await repository.IsIAnswerOptionExistsAsync(request.QuestionId,request.Text);
        if (!questionExists)
        {
            throw new AnswerOptionNotFoundException(nameof(request.QuestionId), request.QuestionId);
        }

        // Map the command to an AnswerOptionEntity
        var answerOptionEntity = mapper.Map<AnswerOptionEntity>(request);

        // Add the new answer option to the repository
        var addedAnswerOption = await repository.AddAsync(answerOptionEntity);

        if (addedAnswerOption.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = addedAnswerOption;
            logger.LogInformation($"Answer option created successfully for Question ID {request.QuestionId}.");
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }

        return responseModel;
    }
}