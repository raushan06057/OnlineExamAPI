namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrganizationListQueryHandler : IRequestHandler<GetOrganizationListQuery, ResponseModel>
{
    private readonly IOrganizationRepository repository;
    private readonly IMapper mapper;
    public GetOrganizationListQueryHandler(IOrganizationRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<ResponseModel> Handle(GetOrganizationListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel response = new();
        var orgList = await repository.GetAsync();
        if (orgList == null)
        {
            throw new OrganizationNotFoundException(nameof(request), null);
        }
        //var result = mapper.Map<List<OrganizationResponse>>(orgList);
        response.Success = true;
        response.Data = orgList;
        return response;
    }
}