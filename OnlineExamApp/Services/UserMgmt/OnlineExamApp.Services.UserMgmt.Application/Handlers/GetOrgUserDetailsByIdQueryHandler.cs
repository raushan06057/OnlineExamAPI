namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgUserDetailsByIdQueryHandler : IRequestHandler<GetOrgUserDetailsByIdQuery, ResponseModel>
{
    private readonly IUserRepository repository;

    public GetOrgUserDetailsByIdQueryHandler(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetOrgUserDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var userDetails = await repository.GetAsync(request.id);

        if (userDetails == null)
        {
            throw new UserDetailsNotFoundException(nameof(request), request.id);
        }
        return userDetails;
    }
}