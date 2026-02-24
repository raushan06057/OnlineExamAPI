namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateOrgDepartmentCommandHandler : IRequestHandler<UpdateOrgDepartmentCommand, ResponseModel>
{
    private readonly IOrgDepartmentRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateOrgDepartmentCommandHandler> logger;
    public UpdateOrgDepartmentCommandHandler(IOrgDepartmentRepository repository, IMapper mapper, ILogger<UpdateOrgDepartmentCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(UpdateOrgDepartmentCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var orgnaizationDept = mapper.Map<OrgDepartmentEntity>(request);
        var orgDeptToUpdate = await repository.GetAsync(request.Id);
        if (orgDeptToUpdate == null)
        {
            throw new OrganizationDeptNotFoundException(nameof(request), request.Id);
        }
        var generateOrg = await repository.UpdateAsync(orgnaizationDept);
        if (generateOrg.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateOrg;
            logger.LogInformation(($"Organization department {generateOrg} successfully updated."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}
