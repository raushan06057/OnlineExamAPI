namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgUserListByOrgIdQueryHandler : IRequestHandler<GetOrgUserListByOrgIdQuery, ResponseModel>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetOrgUserListByOrgIdQueryHandler> logger;
    public GetOrgUserListByOrgIdQueryHandler(IUserRepository repository, IMapper mapper, ILogger<GetOrgUserListByOrgIdQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetOrgUserListByOrgIdQuery request, CancellationToken cancellationToken)
    {
        ApplicationUser user = new ApplicationUser() { OrganizationId = request.OrganizationId };
        var result = await repository.GetAsync(user);
        return result;
    }
}