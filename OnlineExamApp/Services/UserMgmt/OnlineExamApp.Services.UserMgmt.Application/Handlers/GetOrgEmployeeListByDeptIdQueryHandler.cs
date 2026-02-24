namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgEmployeeListByDeptIdQueryHandler : IRequestHandler<GetOrgEmployeeListByDeptIdQuery, ResponseModel>
{
    private readonly IOrgEmployeeRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetOrgEmployeeListByDeptIdQueryHandler> logger;
    public GetOrgEmployeeListByDeptIdQueryHandler(IOrgEmployeeRepository repository, IMapper mapper, ILogger<GetOrgEmployeeListByDeptIdQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetOrgEmployeeListByDeptIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var lst = await repository.GetAsync();
        var orgDeptList = lst.Where(mod => mod.DepartmentId == request.DeptId).ToList();
        responseModel.Success = true;
        responseModel.Data = orgDeptList;
        return responseModel;
    }
}