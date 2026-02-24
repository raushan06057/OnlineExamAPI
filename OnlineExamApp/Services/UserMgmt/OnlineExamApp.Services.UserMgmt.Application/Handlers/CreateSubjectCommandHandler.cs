namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, ResponseModel>
{
    private ISubjectRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateSubjectCommandHandler> logger;
    public CreateSubjectCommandHandler(ISubjectRepository repository, IMapper mapper, ILogger<CreateSubjectCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        try
        {
            var subjectEntity = mapper.Map<SubjectEntity>(request);
            var isExists = await repository.IsSubjectExistsAsync(request.Name,request.CourseId);
            if (isExists)
            {
                throw new SubjectAlreadyExistsException(nameof(request), null);
            }
            else
            {
                var generateOrg = await repository.AddAsync(subjectEntity);
                if (generateOrg.Id != 0)
                {
                    responseModel.Success = true;
                    responseModel.Data = generateOrg;
                    logger.LogInformation(($"Subject {generateOrg} created successfully."));
                    responseModel.Message = CommonResource.RecordSavedSuccessfully;
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