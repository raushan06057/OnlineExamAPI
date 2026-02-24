
namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, ResponseModel>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetUserListQueryHandler> logger;
    public GetUserListQueryHandler(IUserRepository repository, IMapper mapper,
        ILogger<GetUserListQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        OrganizationEntity organization = new() { Id = request.OrganizationId };
        ApplicationUser applicationUser = new() { Organization = organization };
        var responseModel = await repository.GetAsync(applicationUser);
        return responseModel;
    }
}
