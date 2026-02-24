namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, ResponseModel>
{
    private readonly ICourseRepository repository;
    private IMapper mapper;
    private ILogger<DeleteCourseCommandHandler> logger;
    public DeleteCourseCommandHandler(ICourseRepository repository, IMapper mapper, ILogger<DeleteCourseCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var course = mapper.Map<CourseEntity>(request);
        var courseToUpdate = await repository.GetAsync(request.Id);
        if (courseToUpdate == null)
        {
            throw new CourseNotFoundException(nameof(request), request.Id);
        }
        var generateOrg = await repository.DeleteAsync(course);
        if (generateOrg.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateOrg;
            logger.LogInformation(($"Course details {generateOrg} deleted successfully."));
            responseModel.Message = CommonResource.RecordDeletedSuccessfully;
        }
        return responseModel;
    }
}
