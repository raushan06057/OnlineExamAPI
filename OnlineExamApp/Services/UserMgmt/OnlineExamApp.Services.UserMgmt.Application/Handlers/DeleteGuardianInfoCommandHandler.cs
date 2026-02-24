namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteGuardianInfoCommandHandler : IRequestHandler<DeleteGuardianInfoCommand, ResponseModel>
{
    private readonly IGuardianInfoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<DeleteGuardianInfoCommandHandler> logger;

    public DeleteGuardianInfoCommandHandler(
        IGuardianInfoRepository repository,
        IMapper mapper,
        ILogger<DeleteGuardianInfoCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(DeleteGuardianInfoCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Retrieve the guardian to delete
        var guardianToDelete = await repository.GetAsync(request.Id);

        if (guardianToDelete == null)
        {
            throw new GuardianNotFoundException(nameof(request), request.Id);
        }

        // Delete the guardian
        await repository.DeleteAsync(guardianToDelete);

        responseModel.Success = true;
        logger.LogInformation($"Guardian info with Id {request.Id} deleted successfully.");
        responseModel.Message = CommonResource.RecordDeletedSuccessfully;

        return responseModel;
    }
}