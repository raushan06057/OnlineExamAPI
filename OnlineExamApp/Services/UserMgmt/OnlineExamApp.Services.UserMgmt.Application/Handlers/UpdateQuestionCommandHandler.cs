namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, ResponseModel>
{
    private readonly IQuestionRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateQuestionCommandHandler> logger;
    private readonly IAnswerOptionRepository optionRepository;

    public UpdateQuestionCommandHandler(
        IQuestionRepository repository,
        IAnswerOptionRepository optionRepository,
        IMapper mapper,
        ILogger<UpdateQuestionCommandHandler> logger)
    {
        this.repository = repository;
        this.optionRepository = optionRepository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        try
        {


            // Retrieve the question to update
            var questionToUpdate = await repository.GetAsync(request.Id);

            if (questionToUpdate == null)
            {
                throw new QuestionNotFoundException(nameof(request.Id), request.Id);
            }

            // Map the update request to a QuestionEntity
            //var updatedQuestion = mapper.Map<QuestionEntity>(request);
            var updatedQuestion = new QuestionEntity()
            {
                Id = request.Id,
                Text = request.Text,
                Type = request.Type,
                ExamId = request.ExamId,
                Marks = request.Marks
            };

            // Update the question in the repository
            var result = await repository.UpdateAsync(updatedQuestion);

            if (result != null)
            {
                responseModel.Success = true;
                responseModel.Data = null;//result;
                var opitons = request.AnswerOptions;
                if (opitons != null)
                {
                    List<AnswerOptionEntity> answerOptions = new List<AnswerOptionEntity>();
                    List<AnswerOptionEntity> answerOptionsNew = new List<AnswerOptionEntity>();
                    for (int counter = 0; counter < opitons.Count; counter++)
                    {
                        if (request.AnswerOptions[counter].Id > 0)
                        {
                            answerOptions.Add(new AnswerOptionEntity()
                            {
                                Id = opitons[counter].Id,
                                Text = opitons[counter].Text,
                                QuestionId = request.Id,
                                IsCorrect = opitons[counter].IsCorrect,
                            });
                        }
                        else
                        {
                            answerOptionsNew.Add(new AnswerOptionEntity()
                            {
                                Text = opitons[counter].Text,
                                QuestionId = request.Id,
                                IsCorrect = opitons[counter].IsCorrect,
                            });
                        }
                    }
                    if (answerOptions.Count > 0)
                    {
                        await optionRepository.UpdateRangeAsync(answerOptions);
                    }
                    if (answerOptionsNew.Count > 0)
                    {
                        await optionRepository.AddRangeAsync(answerOptionsNew);
                    }
                    logger.LogInformation($"Question with ID {request.Id} updated successfully.");
                    responseModel.Message = CommonResource.RecordUpdatedSuccessfully;
                }
            }
        }
        catch (Exception ex)
        {

            throw;
        }
        return responseModel;
    }
}