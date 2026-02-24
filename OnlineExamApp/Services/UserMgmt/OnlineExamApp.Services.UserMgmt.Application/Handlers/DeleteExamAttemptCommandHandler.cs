namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteExamAttemptCommandHandler : IRequestHandler<DeleteExamAttemptCommand, ResponseModel>
{
    private readonly IExamAttemptRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<DeleteExamAttemptCommandHandler> logger;
    public DeleteExamAttemptCommandHandler(
       IExamAttemptRepository repository,
       IMapper mapper,
       ILogger<DeleteExamAttemptCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(DeleteExamAttemptCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Retrieve the exam attempt to delete
        var examAttemptToDelete = await repository.GetAsync(request.Id);

        if (examAttemptToDelete == null)
        {
            throw new ExamAttemptNotFoundException(nameof(request.Id), request.Id);
        }

        // Delete the exam attempt from the repository
        await repository.DeleteAsync(examAttemptToDelete);

        responseModel.Success = true;
        logger.LogInformation($"Exam attempt with ID {request.Id} deleted successfully.");
        responseModel.Message = CommonResource.RecordDeletedSuccessfully;

        return responseModel;
    }
}