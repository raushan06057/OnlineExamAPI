
namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetOrgByIdQueryHandler : IRequestHandler<GetOrgByIdQuery, ResponseModel>
{
    private readonly IOrganizationRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetOrgByIdQueryHandler> _logger;

    public GetOrgByIdQueryHandler(IOrganizationRepository repository, IMapper mapper, ILogger<GetOrgByIdQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<ResponseModel> Handle(GetOrgByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        try
        {
            var answer = await _repository.GetAsync(request.Id);
            if (answer == null)
            {
                responseModel.Success = false;
                responseModel.Message = "Organization did not find";
            }
            else
            {
                responseModel.Success = true;
                responseModel.Data = answer; // You might want to map it using IMapper if needed.
            }
        }
        catch (Exception ex)
        {
            responseModel.Success = false;
            responseModel.Message = "An error occurred while retrieving the answer.";
            _logger.LogError(ex, "Error retrieving answer by ID");
        }

        return responseModel;
    }
}
