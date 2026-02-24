namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateApplicationUserCommandHandler : IRequestHandler<UpdateApplicationUserCommand, ResponseModel>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateApplicationUserCommandHandler> logger;
    public UpdateApplicationUserCommandHandler(IUserRepository repository, IMapper mapper, ILogger<UpdateApplicationUserCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(UpdateApplicationUserCommand request, CancellationToken cancellationToken)
    {
        var applicationUser = mapper.Map<ApplicationUser>(request);
        var responseModel = await repository.UpdateAsync(applicationUser, request.ClaimList);
        return responseModel;
    }
}
