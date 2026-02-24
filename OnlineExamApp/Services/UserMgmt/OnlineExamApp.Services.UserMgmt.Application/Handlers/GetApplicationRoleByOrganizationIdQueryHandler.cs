namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;
public class GetApplicationRoleByOrganizationIdQueryHandler : IRequestHandler<GetApplicationRoleByOrganizationIdQuery, ResponseModel>
{
    private readonly IRoleRepository repository;
    private IMapper mapper;
    private ILogger<GetApplicationRoleByOrganizationIdQueryHandler> logger;
    public GetApplicationRoleByOrganizationIdQueryHandler(IRoleRepository repository, IMapper mapper, ILogger<GetApplicationRoleByOrganizationIdQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetApplicationRoleByOrganizationIdQuery request, CancellationToken cancellationToken)
    {
        var responseModel = await repository.GetAsync(request.OrganizationId);
        return responseModel;
    }
}