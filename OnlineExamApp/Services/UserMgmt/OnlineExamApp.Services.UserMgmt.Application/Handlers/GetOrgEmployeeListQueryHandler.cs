namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgEmployeeListQueryHandler : IRequestHandler<GetOrgEmployeeListQuery, ResponseModel>
{
    private readonly IOrgEmployeeRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetOrgEmployeeListQueryHandler> logger;
    public GetOrgEmployeeListQueryHandler(IOrgEmployeeRepository repository, IMapper mapper, ILogger<GetOrgEmployeeListQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetOrgEmployeeListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var lst = await repository.GetAsync();
        responseModel.Success = true;
        responseModel.Data = lst;
        return responseModel;
    }
}