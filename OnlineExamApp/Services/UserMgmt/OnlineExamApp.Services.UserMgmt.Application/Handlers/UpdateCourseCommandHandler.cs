namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ResponseModel>
{
    private readonly ICourseRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateCourseCommandHandler> logger;
    public UpdateCourseCommandHandler(ICourseRepository repository, IMapper mapper, ILogger<UpdateCourseCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var course = mapper.Map<CourseEntity>(request);
        var courseToUpdate = await repository.GetAsync(request.Id);
        if (courseToUpdate == null)
        {
            throw new CourseNotFoundException(nameof(request), request.Id);
        }
        var generateOrg = await repository.UpdateAsync(course);
        if (generateOrg.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateOrg;
            logger.LogInformation(($"Course {generateOrg} updated successfully."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}
