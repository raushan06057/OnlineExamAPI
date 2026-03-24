namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateStudentQuestionAttemptCommandHandler : IRequestHandler<CreateStudentQuestionAttemptCommand, ResponseModel>
{
    private readonly IStudentQuestionAttemptRepository repository;
    private IMapper mapper;
    private ILogger<CreateStudentQuestionAttemptCommandHandler> logger;
    private readonly IStudentInfoRepository studentInfoRepository;
    private readonly IAttemptAnswersRepository attemptAnswersRepository;
    private readonly IAnswerOptionRepository answerOptionRepository;

    public CreateStudentQuestionAttemptCommandHandler(IStudentQuestionAttemptRepository repository,
        IMapper mapper, ILogger<CreateStudentQuestionAttemptCommandHandler> logger,
        IStudentInfoRepository studentInfoRepository, IAttemptAnswersRepository attemptAnswersRepository,
        IAnswerOptionRepository answerOptionRepository)
    {
        this.repository = repository;
        this.studentInfoRepository = studentInfoRepository;
        this.attemptAnswersRepository = attemptAnswersRepository;
        this.answerOptionRepository = answerOptionRepository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(CreateStudentQuestionAttemptCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var questionAttemptDtl = mapper.Map<QuestionAttemptEntity>(request);
        var studentInfo = await studentInfoRepository.GetQueryAsync().FirstOrDefaultAsync(mod => mod.UserId == request.CreatedBy);
        //questionAttemptDtl.QuestionId=request.Id;
        var isRecordExists = await repository.HasQuestionAttemptAsync(questionAttemptDtl);
        if (isRecordExists)
        {
            // throw new QuestionAttemptAlreadyExistsException(nameof(request), null);
            responseModel.Success= false;
            responseModel.Message = CommonResource.QuestionAttemptAlreadyExists;
            return responseModel;
        }
        questionAttemptDtl.StudentInfoId = studentInfo.Id;
        questionAttemptDtl.CreatedOn = DateTime.UtcNow;
        var questionAttempt = await repository.AddAsync(questionAttemptDtl);
        if (questionAttempt.Id != 0)
        {
            if (request.AnswerOptions != null && request.AnswerOptions.Count > 0)
            {
                var answerOptions = await answerOptionRepository.GetAsync(mod => mod.QuestionId == request.QuestionId);
                List<AttemptAnswerEntity> lst = new();
                var isCorrect = false;
                foreach (var answer in request.AnswerOptions)
                {
                    if (answer.IsCorrect == true)
                    {
                        isCorrect = answerOptions.Where(mod => mod.QuestionId == request.QuestionId && mod.Id == answer.Id && mod.IsCorrect == true).Any();
                        lst.Add(new AttemptAnswerEntity()
                        {
                            QuestionAttemptId = questionAttempt.Id,
                            AnswerOptionsId = answer.Id,
                            IsSelected = answer.IsCorrect,
                            IsCorrect = isCorrect
                        });
                        await attemptAnswersRepository.AddRangeAsync(lst);
                    }
                }
            }
            responseModel.Success = true;
            responseModel.Data = questionAttempt;
            logger.LogInformation(($"Question attempt details {questionAttempt} saved successfully."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}
