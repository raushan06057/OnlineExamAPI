namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgDepartmentByOrganizationIdQueryHandler : IRequestHandler<GetOrgDepartmentByOrganizationIdQuery, ResponseModel>
{
    private readonly IOrgDepartmentRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetOrgDepartmentByOrganizationIdQuery> logger;
    public GetOrgDepartmentByOrganizationIdQueryHandler(IOrgDepartmentRepository repository, IMapper mapper, ILogger<GetOrgDepartmentByOrganizationIdQuery> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetOrgDepartmentByOrganizationIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var lst = await repository.GetAsync();
        var orgDeptList=lst.Where(mod=>mod.OrganizationId == request.OrganizationId).ToList();
        responseModel.Success = true;
        responseModel.Data = orgDeptList;
        return responseModel;
    }
}
