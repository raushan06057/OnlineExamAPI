namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgDepartmentListQueryHandler : IRequestHandler<GetOrgDepartmentListQuery, ResponseModel>
{
    private readonly IOrgDepartmentRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetOrgDepartmentListQueryHandler> logger;
    public GetOrgDepartmentListQueryHandler(IOrgDepartmentRepository repository, IMapper mapper, ILogger<GetOrgDepartmentListQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetOrgDepartmentListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var orgDeptList = await repository.GetDeptWithOrgAsync();
        responseModel.Success = true;
        responseModel.Data = orgDeptList;
        return responseModel;
    }
}
