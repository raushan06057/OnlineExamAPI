namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateGuardianInfoCommandHandler : IRequestHandler<UpdateGuardianInfoCommand, ResponseModel>
{
    private readonly IGuardianInfoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateGuardianInfoCommandHandler> logger;

    public UpdateGuardianInfoCommandHandler(
        IGuardianInfoRepository repository,
        IMapper mapper,
        ILogger<UpdateGuardianInfoCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(UpdateGuardianInfoCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Map the command to the entity
        var guardianEntity = mapper.Map<GuardianInfoEntity>(request);

        // Retrieve the guardian to update
        var existingGuardian = await repository.GetAsync(request.Id);

        if (existingGuardian == null)
        {
            throw new GuardianNotFoundException(nameof(request), request.Id);
        }

        // Update the guardian information
        var updatedGuardian = await repository.UpdateAsync(guardianEntity);

        if (updatedGuardian.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = updatedGuardian;
            logger.LogInformation($"Guardian info {updatedGuardian} updated successfully.");
            responseModel.Message = CommonResource.RecordUpdatedSuccessfully;
        }

        return responseModel;
    }
}