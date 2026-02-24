namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, ResponseModel>
{
    private readonly IOrganizationRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateOrganizationCommandHandler> logger;
    public UpdateOrganizationCommandHandler(IOrganizationRepository repository, IMapper mapper, ILogger<UpdateOrganizationCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var orgnaization = mapper.Map<OrganizationEntity>(request);

        var orgToUpdate = await repository.GetAsync(request.Id);
        if (orgToUpdate == null)
        {
            throw new OrganizationDeptNotFoundException(nameof(request),request.Id);
        }
        var generateOrg = await repository.UpdateAsync(orgnaization);
        if (generateOrg.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateOrg;
            logger.LogInformation(($"Organization dept {generateOrg} successfully updated."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}