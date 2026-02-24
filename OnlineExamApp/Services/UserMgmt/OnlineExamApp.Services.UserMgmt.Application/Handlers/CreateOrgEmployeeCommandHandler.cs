namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateOrgEmployeeCommandHandler : IRequestHandler<CreateOrgEmployeeCommand, ResponseModel>
{
    private readonly IOrgEmployeeRepository repository;
    private IMapper mapper;
    private ILogger<CreateOrgEmployeeCommandHandler> logger;
    public CreateOrgEmployeeCommandHandler(IOrgEmployeeRepository repository, IMapper mapper, ILogger<CreateOrgEmployeeCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(CreateOrgEmployeeCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var emailExists = await repository.IsEmailExistsAsync(request.EmailAddress);
        if (emailExists)
        {
            throw new EmailAddressAlreadyExistsException(nameof(request), null);
        }
        else
        {
            var employeeDtl = mapper.Map<OrgEmployeeEntity>(request);
            var employee = await repository.AddAsync(employeeDtl);
            if (employee.Id != 0)
            {
                responseModel.Success = true;
                responseModel.Data = employee;
                logger.LogInformation(($"Employee details {employee} saved successfully."));
                responseModel.Message = CommonResource.RecordSavedSuccessfully;
            }
        }
        return responseModel;
    }
}
