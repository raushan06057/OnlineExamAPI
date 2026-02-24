namespace OnlineExamApp.Services.AnswerMgmt.Application.Handlers;

public class GetAnswerByIdQueryHandler : IRequestHandler<GetAnswerByIdQuery, ResponseModel>
{
    private readonly IAnswerRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAnswerByIdQueryHandler> _logger;

    public GetAnswerByIdQueryHandler(IAnswerRepository repository, IMapper mapper, ILogger<GetAnswerByIdQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ResponseModel> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        try
        {
            var answer = await _repository.GetAsync(request.Id);
            if (answer == null)
            {
                responseModel.Success = false;
                responseModel.Message = "Answer not found";
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