
namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetApplicationRoleByIdQueryHandler : IRequestHandler<GetApplicationRoleByIdQuery, ResponseModel>
{
    private readonly IRoleRepository repository;
    private IMapper mapper;
    private ILogger<GetApplicationRoleByIdQueryHandler> logger;
    public GetApplicationRoleByIdQueryHandler(IRoleRepository repository, IMapper mapper, ILogger<GetApplicationRoleByIdQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
   
    public async Task<ResponseModel> Handle(GetApplicationRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var responseModel = await repository.GetAsync(request.Id);
        return responseModel;
    }
}
