namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgEmployeeByRoleIdQueryHandler : IRequestHandler<GetOrgEmployeeByRoleIdQuery, ResponseModel>
{
    private readonly IOrgEmployeeRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetOrgEmployeeByRoleIdQueryHandler> logger;
    public GetOrgEmployeeByRoleIdQueryHandler(IOrgEmployeeRepository repository, IMapper mapper, ILogger<GetOrgEmployeeByRoleIdQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetOrgEmployeeByRoleIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var lst = await repository.GetAsync();
        var orgDeptList = lst.Where(mod => mod.EmployeeRoleId == request.RoleId).ToList();
        responseModel.Success = true;
        responseModel.Data = orgDeptList;
        return responseModel;
    }
}
