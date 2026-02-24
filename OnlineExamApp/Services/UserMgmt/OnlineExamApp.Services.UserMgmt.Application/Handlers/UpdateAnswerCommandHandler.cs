namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, ResponseModel>
{
    private readonly IAnswerRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateAnswerCommandHandler> logger;

    public UpdateAnswerCommandHandler(IAnswerRepository repository, IMapper mapper, ILogger<UpdateAnswerCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Map the update request to an AnswerEntity
        var answer = mapper.Map<AnswerEntity>(request);

        // Check if the answer exists
        var answerToUpdate = await repository.GetAsync(request.Id);
        if (answerToUpdate == null)
        {
            throw new AnswerNotFoundException(nameof(request.Id), request.Id);
        }

        // Update the answer in the repository
        var updatedAnswer = await repository.UpdateAsync(answer);

        if (updatedAnswer.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = updatedAnswer;
            logger.LogInformation($"Answer with ID {request.Id} updated successfully.");
            responseModel.Message = CommonResource.RecordUpdatedSuccessfully;
        }

        return responseModel;
    }
}