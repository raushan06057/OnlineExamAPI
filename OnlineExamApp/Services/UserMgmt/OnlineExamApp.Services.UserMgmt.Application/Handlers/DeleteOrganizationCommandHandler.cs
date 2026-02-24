namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand, ResponseModel>
{
    private readonly IOrganizationRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<DeleteOrganizationCommandHandler> logger;
    public DeleteOrganizationCommandHandler(IOrganizationRepository repository, IMapper mapper, ILogger<DeleteOrganizationCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var orgnaization = mapper.Map<OrganizationEntity>(request);
        var orgToUpdate = await repository.GetAsync(request.Id);
        if (orgToUpdate == null)
        {
            throw new OrganizationNotFoundException(nameof(request), request.Id);
        }
        var generateOrg = await repository.DeleteAsync(orgnaization);
        if (generateOrg.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateOrg;
            logger.LogInformation(($"Organization {generateOrg} deleted successfully."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}
