namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteOrgEmployeeCommandHandler : IRequestHandler<DeleteOrgEmployeeCommand, ResponseModel>
{
    private readonly IOrgEmployeeRepository repository;
    private IMapper mapper;
    private ILogger<DeleteOrgEmployeeCommandHandler> logger;
    public DeleteOrgEmployeeCommandHandler(IOrgEmployeeRepository repository, IMapper mapper, ILogger<DeleteOrgEmployeeCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(DeleteOrgEmployeeCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var employee = mapper.Map<OrgEmployeeEntity>(request);
        var empToUpdate = await repository.GetAsync(request.Id);
        if (empToUpdate == null)
        {
            throw new OrganizationDeptNotFoundException(nameof(request), request.Id);
        }
        var generateOrg = await repository.DeleteAsync(employee);
        if (generateOrg.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateOrg;
            logger.LogInformation(($"Employee details {generateOrg} deleted successfully."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}