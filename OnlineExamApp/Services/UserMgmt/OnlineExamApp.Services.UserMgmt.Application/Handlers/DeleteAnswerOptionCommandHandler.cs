namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteAnswerOptionCommandHandler : IRequestHandler<DeleteAnswerOptionCommand, ResponseModel>
{
    private readonly IAnswerOptionRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<DeleteAnswerOptionCommandHandler> logger;

    public DeleteAnswerOptionCommandHandler(
        IAnswerOptionRepository repository,
        IMapper mapper,
        ILogger<DeleteAnswerOptionCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(DeleteAnswerOptionCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Retrieve the answer option to delete
        var answerOptionToDelete = await repository.GetAsync(request.Id);

        if (answerOptionToDelete == null)
        {
            throw new AnswerOptionNotFoundException(nameof(request.Id), request.Id);
        }

        // Delete the answer option from the repository
        await repository.DeleteAsync(answerOptionToDelete);

        responseModel.Success = true;
        logger.LogInformation($"Answer option with ID {request.Id} deleted successfully.");
        responseModel.Message = CommonResource.RecordDeletedSuccessfully;

        return responseModel;
    }
}