
namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgEmployeeListByOrgIdQueryHandler : IRequestHandler<GetOrgEmployeeListByOrgIdQuery, ResponseModel>
{
    private readonly IOrgEmployeeRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetOrgEmployeeListByOrgIdQueryHandler> logger;
    public GetOrgEmployeeListByOrgIdQueryHandler(IOrgEmployeeRepository repository, IMapper mapper, ILogger<GetOrgEmployeeListByOrgIdQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetOrgEmployeeListByOrgIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var lst = await repository.GetAsync();
        var orgDeptList = lst.Where(mod => mod.OrganizationId == request.OrganizationId).ToList();
        responseModel.Success = true;
        responseModel.Data = orgDeptList;
        return responseModel;
    }
}
