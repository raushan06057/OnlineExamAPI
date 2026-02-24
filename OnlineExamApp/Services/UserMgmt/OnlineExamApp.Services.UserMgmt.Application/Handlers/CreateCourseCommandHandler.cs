namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, ResponseModel>
{
    private readonly ICourseRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateCourseCommandHandler> logger;
    public CreateCourseCommandHandler(ICourseRepository repository, IMapper mapper, ILogger<CreateCourseCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        try
        {
            var courseEnrollment = mapper.Map<CourseEntity>(request);
            var isExists = await repository.IsCourseExistsAsync(request.Title);
            if (isExists)
            {
                throw new CourseAlreadyExistsException(nameof(request), null);
            }
            else
            {
                var generateOrg = await repository.AddAsync(courseEnrollment);
                if (generateOrg.Id != 0)
                {
                    responseModel.Success = true;
                    responseModel.Data = generateOrg;
                    logger.LogInformation(($"Course {generateOrg} created successfully."));
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
