namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateOrgDepartmentCommandHandler : IRequestHandler<CreateOrgDepartmentCommand, ResponseModel>
{
    private readonly IOrgDepartmentRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateOrgDepartmentCommandHandler> logger;
    public CreateOrgDepartmentCommandHandler(IOrgDepartmentRepository repository, IMapper mapper, ILogger<CreateOrgDepartmentCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(CreateOrgDepartmentCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var orgnaization = mapper.Map<OrgDepartmentEntity>(request);
        var isExists = await repository.IsNameExistsAsync(request.Name,request.OrganizationId);
        if (isExists)
        {
            responseModel.Success= false;
            responseModel.Message= CommonResource.OrganizationDepartmentAlreadyExists;
            //throw new OrganizationDepartmentAlreadyExistsException(nameof(request), null);
        }
        else
        {
            var generateOrg = await repository.AddAsync(orgnaization);
            if (generateOrg.Id != 0)
            {
                responseModel.Success = true;
                responseModel.Data = generateOrg;
                logger.LogInformation(($"Organization department {generateOrg} successfully created."));
                responseModel.Message = CommonResource.RecordSavedSuccessfully;
            }
        }

        return responseModel;
    }
}