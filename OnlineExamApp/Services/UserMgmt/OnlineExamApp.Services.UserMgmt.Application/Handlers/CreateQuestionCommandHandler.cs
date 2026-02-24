namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, ResponseModel>
{
    private readonly IQuestionRepository repository;
    private readonly IAnswerOptionRepository optionRepository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateQuestionCommandHandler> logger;

    public CreateQuestionCommandHandler(
        IQuestionRepository repository,
        IMapper mapper,
        IAnswerOptionRepository optionRepository,
        ILogger<CreateQuestionCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.optionRepository = optionRepository;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Map the command to a QuestionEntity
        var questionEntity = mapper.Map<QuestionEntity>(request);

        // Check if the exam exists (optional but recommended)
        var examExists = await repository.IsQuestionExistsAsync(request.ExamId, request.Text);
        if (examExists)
        {
            //throw new ExamNotFoundException(nameof(request.ExamId), request.ExamId);
            responseModel.Success=false;
            responseModel.Message = $"Entity {request.ExamId} not found.";
        }

        // Add the new question to the repository
        var addedQuestion = await repository.AddAsync(questionEntity);

        if (addedQuestion.Id != 0)
        {
            //List<AnswerOptionEntity> answerOptionEntities = new List<AnswerOptionEntity>();
            //for (int counter = 0; counter < request.AnswerOptions.Count; counter++)
            //{
            //    answerOptionEntities.Add(new AnswerOptionEntity()
            //    {
            //        QuestionId = addedQuestion.Id,
            //        Text = request.AnswerOptions[counter].Text,
            //        IsCorrect = request.AnswerOptions[counter].IsCorrect
            //    });
            //}
            //await optionRepository.AddRangeAsync(answerOptionEntities);
            responseModel.Success = true;
            //responseModel.Data = addedQuestion;
            logger.LogInformation($"Question created successfully for Exam ID {request.ExamId}.");
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }

        return responseModel;
    }
}