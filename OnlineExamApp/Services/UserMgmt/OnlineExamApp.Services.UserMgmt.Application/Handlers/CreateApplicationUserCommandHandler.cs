namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateApplicationUserCommandHandler : IRequestHandler<CreateApplicationUserCommand,ResponseModel>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateApplicationUserCommandHandler> logger;
    public CreateApplicationUserCommandHandler(IUserRepository repository, IMapper mapper, ILogger<CreateApplicationUserCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
    {
        var applicationUser = mapper.Map<ApplicationUser>(request);
        var responseModel = await repository.CreateAsync(applicationUser, request.ClaimList);
        return responseModel;
    }
}