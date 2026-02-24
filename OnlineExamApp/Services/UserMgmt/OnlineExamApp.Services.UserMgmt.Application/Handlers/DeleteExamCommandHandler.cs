namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand, ResponseModel>
{
    private readonly IExamRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<DeleteExamCommandHandler> logger;

    public DeleteExamCommandHandler(
        IExamRepository repository,
        IMapper mapper,
        ILogger<DeleteExamCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Retrieve the exam to delete
        var examToDelete = await repository.GetAsync(request.Id);

        if (examToDelete == null)
        {
            throw new ExamNotFoundException(nameof(request.Id), request.Id);
        }

        // Delete the exam
        await repository.DeleteAsync(examToDelete);

        responseModel.Success = true;
        logger.LogInformation($"Exam with Id {request.Id} deleted successfully.");
        responseModel.Message = CommonResource.RecordDeletedSuccessfully;

        return responseModel;
    }
}