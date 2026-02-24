namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgDepartmentByIdQueryHandler : IRequestHandler<GetOrgDepartmentByIdQuery, ResponseModel>
{
    private readonly IOrgDepartmentRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetOrgDepartmentByIdQueryHandler> logger;
    public GetOrgDepartmentByIdQueryHandler(IOrgDepartmentRepository repository, IMapper mapper, ILogger<GetOrgDepartmentByIdQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetOrgDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var orgDeptList = await repository.GetAsync(request.Id);
        responseModel.Success = true;
        responseModel.Data = orgDeptList;
        return responseModel;
    }
}
