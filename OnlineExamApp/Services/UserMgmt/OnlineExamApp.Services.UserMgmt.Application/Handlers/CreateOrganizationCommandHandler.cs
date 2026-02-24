namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, ResponseModel>
{
    private readonly IOrganizationRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateOrganizationCommandHandler> logger;
    public CreateOrganizationCommandHandler(IOrganizationRepository repository, IMapper mapper, ILogger<CreateOrganizationCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var orgnaization = mapper.Map<OrganizationEntity>(request);
        var isExists = await repository.IsNameExistsAsync(request.Name);
        if (isExists) 
        {
            throw new OrganizationAlreadyExistsException(nameof(request), null);
        }
        else
        {
            var generateOrg = await repository.AddAsync(orgnaization);
            if (generateOrg.Id != 0)
            {
                responseModel.Success = true;
                responseModel.Data = generateOrg;
                logger.LogInformation(($"Organization {generateOrg} successfully created."));
                responseModel.Message = CommonResource.RecordSavedSuccessfully;
            }
        }
        
        return responseModel;
    }
}
