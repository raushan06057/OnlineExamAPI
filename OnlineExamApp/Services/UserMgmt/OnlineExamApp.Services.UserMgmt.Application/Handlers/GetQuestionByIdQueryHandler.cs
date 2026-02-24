namespace OnlineExamApp.Services.QuestionMgmt.Application.Handlers;

public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, ResponseModel>
{
    private readonly IQuestionRepository repository;
    private readonly IAnswerOptionRepository optionRepository;
    private readonly IMapper mapper;
    private readonly ILogger<GetQuestionByIdQueryHandler> logger;

    public GetQuestionByIdQueryHandler(IQuestionRepository repository,
        IAnswerOptionRepository optionRepository,
        IMapper mapper,
        ILogger<GetQuestionByIdQueryHandler> logger)
    {
        this.repository = repository;
        this.optionRepository = optionRepository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        try
        {
            var question = await repository.GetAsync(request.Id);
            if (question == null)
            {
                responseModel.Success = false;
                responseModel.Message = "Question not found";
            }
            else
            {
                var result = mapper.Map<QuestionResponse>(question);
                Expression<Func<AnswerOptionEntity, bool>> predicate = ans => ans.QuestionId ==request.Id;
                var answerOptionEntities=await optionRepository.GetAsync(predicate);
                result.AnswerOptions = answerOptionEntities.ToList();
                responseModel.Success = true;
                responseModel.Data = result; // You might want to map it using IMapper if needed.
            }
        }
        catch (Exception ex)
        {
            responseModel.Success = false;
            responseModel.Message = "An error occurred while retrieving the question.";
            logger.LogError(ex, "Error retrieving question by ID");
        }

        return responseModel;
    }
}