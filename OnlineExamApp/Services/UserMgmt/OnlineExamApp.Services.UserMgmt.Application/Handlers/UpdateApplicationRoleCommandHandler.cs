
namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateApplicationRoleCommandHandler : IRequestHandler<UpdateApplicationRoleCommand, ResponseModel>
{
    private readonly IRoleRepository repository;
    private IMapper mapper;
    private ILogger<UpdateApplicationRoleCommandHandler> logger;
    public UpdateApplicationRoleCommandHandler(IRoleRepository repository,IMapper mapper, ILogger<UpdateApplicationRoleCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(UpdateApplicationRoleCommand request, CancellationToken cancellationToken)
    {
        var applicationRole = mapper.Map<ApplicationRole>(request);
        var responseModel = await repository.UpdateAsync(applicationRole);
        return responseModel;
    }
}
