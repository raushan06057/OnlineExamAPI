namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, ResponseModel>
{
    private readonly IExamRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateExamCommandHandler> logger;

    public CreateExamCommandHandler(IExamRepository repository, IMapper mapper, ILogger<CreateExamCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(CreateExamCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Map the command to an ExamEntity
        var examEntity = mapper.Map<ExamEntity>(request);

        // Check if an exam with the same title already exists
        var isExists = await repository.IsExamExistsAsync(request.Title,request.OrganizationId);
        if (isExists)
        {
            //throw new ExamAlreadyExistsException(nameof(request), null);
            responseModel.Success = false;
            responseModel.Message = $"Exam '{request.Title}' already exists.";
        }
        else
        {
            // Add the new exam to the repository
            var addedExam = await repository.AddAsync(examEntity);

            // Check if the addition was successful
            if (addedExam.Id != 0)
            {
                responseModel.Success = true;
                responseModel.Data = addedExam;
                logger.LogInformation($"Exam {addedExam.Title} created successfully.");
                responseModel.Message = CommonResource.RecordSavedSuccessfully;
            }
        }

        return responseModel;
    }
}