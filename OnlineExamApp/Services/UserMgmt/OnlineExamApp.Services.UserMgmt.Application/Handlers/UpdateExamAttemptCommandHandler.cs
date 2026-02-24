namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateExamAttemptCommandHandler : IRequestHandler<UpdateExamAttemptCommand, ResponseModel>
{
    private readonly IExamAttemptRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateExamAttemptCommandHandler> logger;

    public UpdateExamAttemptCommandHandler(
        IExamAttemptRepository repository,
        IMapper mapper,
        ILogger<UpdateExamAttemptCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(UpdateExamAttemptCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Retrieve the exam attempt to update
        var existingExamAttempt = await repository.GetAsync(request.Id);

        if (existingExamAttempt == null)
        {
            throw new ExamAttemptNotFoundException(nameof(request.Id), request.Id);
        }

        // Map the update request to an ExamAttemptEntity
        var updatedExamAttempt = mapper.Map<ExamAttemptEntity>(request);

        // Update the exam attempt in the repository
        var result = await repository.UpdateAsync(updatedExamAttempt);

        if (result != null)
        {
            responseModel.Success = true;
            responseModel.Data = result;
            logger.LogInformation($"Exam attempt with ID {request.Id} updated successfully.");
            responseModel.Message = CommonResource.RecordUpdatedSuccessfully;
        }

        return responseModel;
    }
}