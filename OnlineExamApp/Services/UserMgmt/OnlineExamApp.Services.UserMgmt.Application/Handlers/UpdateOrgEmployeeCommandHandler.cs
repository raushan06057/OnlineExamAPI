namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateOrgEmployeeCommandHandler : IRequestHandler<UpdateOrgEmployeeCommand, ResponseModel>
{
    private readonly IOrgEmployeeRepository repository;
    private IMapper mapper;
    private ILogger<UpdateOrgEmployeeCommandHandler> logger;
    public UpdateOrgEmployeeCommandHandler(IOrgEmployeeRepository repository, IMapper mapper, ILogger<UpdateOrgEmployeeCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(UpdateOrgEmployeeCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var employee = mapper.Map<OrgEmployeeEntity>(request);
        var empToUpdate = await repository.GetAsync(request.Id);
        if (empToUpdate == null)
        {
            throw new EmployeeNotFoundException(nameof(request), request.Id);
        }
        var generateEmp = await repository.UpdateAsync(employee);
        if (generateEmp.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateEmp;
            logger.LogInformation(($"Employee {generateEmp} successfully updated."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}