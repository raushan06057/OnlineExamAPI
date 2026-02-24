namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, ResponseModel>
{
    private readonly IQuestionRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<DeleteQuestionCommandHandler> logger;

    public DeleteQuestionCommandHandler(
        IQuestionRepository repository,
        IMapper mapper,
        ILogger<DeleteQuestionCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Retrieve the question to delete
        var questionToDelete = await repository.GetAsync(request.Id);

        if (questionToDelete == null)
        {
            throw new QuestionNotFoundException(nameof(request.Id), request.Id);
        }

        // Delete the question from the repository
        await repository.DeleteAsync(questionToDelete);

        responseModel.Success = true;
        logger.LogInformation($"Question with ID {request.Id} deleted successfully.");
        responseModel.Message = CommonResource.RecordDeletedSuccessfully;

        return responseModel;
    }
}