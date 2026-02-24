namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateGuardianInfoCommandHandler : IRequestHandler<CreateGuardianInfoCommand, ResponseModel>
{
    private readonly IGuardianInfoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateGuardianInfoCommandHandler> logger;

    public CreateGuardianInfoCommandHandler(
        IGuardianInfoRepository repository,
        IMapper mapper,
        ILogger<CreateGuardianInfoCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(CreateGuardianInfoCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Map the command to the entity
        var guardianEntity = mapper.Map<GuardianInfoEntity>(request);

        // Check if a guardian with the same email already exists (optional)
        var isExists = await repository.IsGuardianInfoExistsAsync(request.StudentId,0);
        if (isExists)
        {
            throw new GuardianAlreadyExistsException(nameof(request), null);
        }

        // Add the new guardian
        var createdGuardian = await repository.AddAsync(guardianEntity);

        if (createdGuardian.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = createdGuardian;
            logger.LogInformation($"Guardian info {createdGuardian} created successfully.");
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }

        return responseModel;
    }
}
