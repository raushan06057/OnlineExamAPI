
namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgEmployeeByIdQueryHandler : IRequestHandler<GetOrgEmployeeByIdQuery, ResponseModel>
{
    private readonly IOrgEmployeeRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetOrgEmployeeByIdQueryHandler> logger;
    public GetOrgEmployeeByIdQueryHandler(IOrgEmployeeRepository repository, IMapper mapper, ILogger<GetOrgEmployeeByIdQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetOrgEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var lst = await repository.GetAsync();
        var orgDeptList = lst.Where(mod => mod.Id == request.EmpId).ToList();
        responseModel.Success = true;
        responseModel.Data = orgDeptList;
        return responseModel;
    }
}
