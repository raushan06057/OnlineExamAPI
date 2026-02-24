
namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseModel>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<LoginCommandHandler> logger;
    public LoginCommandHandler(IUserRepository repository, IMapper mapper, ILogger<LoginCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var responseModel = await repository.LoginAsync(request.Username,request.Password);
        return responseModel;
    }
}
