namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateApplicationRoleCommandHandler : IRequestHandler<CreateApplicationRoleCommand, ResponseModel>
{
    private readonly IRoleRepository repository;
    private IMapper mapper;
    private ILogger<CreateApplicationRoleCommandHandler> logger;
    public CreateApplicationRoleCommandHandler(IRoleRepository repository, IMapper mapper, ILogger<CreateApplicationRoleCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(CreateApplicationRoleCommand request, CancellationToken cancellationToken)
    {
        var applicationRole = mapper.Map<ApplicationRole>(request);
        var responseModel = await repository.CreateAsync(applicationRole);
        return responseModel;
    }
}
