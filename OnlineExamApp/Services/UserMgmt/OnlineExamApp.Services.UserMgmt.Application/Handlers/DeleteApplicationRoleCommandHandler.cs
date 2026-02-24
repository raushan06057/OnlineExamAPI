
namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteApplicationRoleCommandHandler : IRequestHandler<DeleteApplicationRoleCommand, ResponseModel>
{
    private readonly IRoleRepository repository;
    private IMapper mapper;
    private ILogger<DeleteApplicationRoleCommandHandler> logger;
    public DeleteApplicationRoleCommandHandler(IRoleRepository repository,IMapper mapper,ILogger<DeleteApplicationRoleCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(DeleteApplicationRoleCommand request, CancellationToken cancellationToken)
    {
        var applicationRole = mapper.Map<ApplicationRole>(request);
        var responseModel = await repository.DeleteAsync(applicationRole);
        return responseModel;
    }
}
