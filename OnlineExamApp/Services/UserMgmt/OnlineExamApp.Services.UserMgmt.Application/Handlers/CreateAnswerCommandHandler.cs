namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, ResponseModel>
{
    private readonly IAnswerRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateAnswerCommandHandler> logger;

    public CreateAnswerCommandHandler(
        IAnswerRepository repository,
        IMapper mapper,
        ILogger<CreateAnswerCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        //// Check if the question exists
        //var questionExists = await repository(request.QuestionId);
        //if (!questionExists)
        //{
        //    throw new QuestionNotFoundException(nameof(request.QuestionId), request.QuestionId);
        //}

        // Map the command to an AnswerEntity
        var answerEntity = mapper.Map<AnswerEntity>(request);

        // Add the new answer to the repository
        var addedAnswer = await repository.AddAsync(answerEntity);

        if (addedAnswer.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = addedAnswer;
            logger.LogInformation($"Answer created successfully for Question ID {request.QuestionId}.");
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }

        return responseModel;
    }
}