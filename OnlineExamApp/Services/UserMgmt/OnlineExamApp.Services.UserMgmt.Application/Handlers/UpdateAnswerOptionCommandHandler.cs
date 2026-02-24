namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateAnswerOptionCommandHandler : IRequestHandler<UpdateAnswerOptionCommand, ResponseModel>
{
    private readonly IAnswerOptionRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateAnswerOptionCommandHandler> logger;

    public UpdateAnswerOptionCommandHandler(
        IAnswerOptionRepository repository,
        IMapper mapper,
        ILogger<UpdateAnswerOptionCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(UpdateAnswerOptionCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Retrieve the answer option to update
        var answerOptionToUpdate = await repository.GetAsync(request.Id);

        if (answerOptionToUpdate == null)
        {
            throw new AnswerOptionNotFoundException(nameof(request.Id), request.Id);
        }

        // Map the update request to an AnswerOptionEntity
        var updatedAnswerOption = mapper.Map<AnswerOptionEntity>(request);

        // Update the answer option in the repository
        var result = await repository.UpdateAsync(updatedAnswerOption);

        if (result != null)
        {
            responseModel.Success = true;
            responseModel.Data = result;
            logger.LogInformation($"Answer option with ID {request.Id} updated successfully.");
            responseModel.Message = CommonResource.RecordUpdatedSuccessfully;
        }

        return responseModel;
    }
}