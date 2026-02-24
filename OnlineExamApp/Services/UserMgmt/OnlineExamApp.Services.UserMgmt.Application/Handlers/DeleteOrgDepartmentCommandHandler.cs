namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteOrgDepartmentCommandHandler : IRequestHandler<DeleteOrgDepartmentCommand, ResponseModel>
{
    private readonly IOrgDepartmentRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<DeleteOrgDepartmentCommandHandler> logger;
    public DeleteOrgDepartmentCommandHandler(IOrgDepartmentRepository repositor, IMapper mapper, ILogger<DeleteOrgDepartmentCommandHandler> logger)
    {
        this.repository = repositor;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(DeleteOrgDepartmentCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var orgnaization = mapper.Map<OrgDepartmentEntity>(request);
        var orgToUpdate = await repository.GetAsync(request.Id);
        if (orgToUpdate == null)
        {
            throw new OrganizationDeptNotFoundException(nameof(request), request.Id);
        }
        var generateOrg = await repository.DeleteAsync(orgnaization);
        if (generateOrg.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateOrg;
            logger.LogInformation(($"Organization dept {generateOrg} deleted successfully."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}
