namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateExamAttemptCommandHandler : IRequestHandler<CreateExamAttemptCommand, ResponseModel>
{
    private readonly IExamAttemptRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateExamAttemptCommandHandler> logger;

    public CreateExamAttemptCommandHandler(
        IExamAttemptRepository repository,
        IMapper mapper,
        ILogger<CreateExamAttemptCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(CreateExamAttemptCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Check if the student and exam exist (optional but recommended)
        var isExamAttemptExists = await repository.IsExamAttemptExistsAsync(request.StudentId, request.ExamId);
        if (isExamAttemptExists)
        {
            throw new ExamAttemptAlreadyExistsException(nameof(request.StudentId), request.ExamId);
        }
        // Map the command to an ExamAttemptEntity
        var examAttemptEntity = mapper.Map<ExamAttemptEntity>(request);

        // Add the new exam attempt to the repository
        var addedExamAttempt = await repository.AddAsync(examAttemptEntity);

        if (addedExamAttempt.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = addedExamAttempt;
            logger.LogInformation($"Exam attempt for Student ID {request.StudentId} and Exam ID {request.ExamId} saved successfully.");
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}