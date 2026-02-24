namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteCourseEnrollmentCommandHandler : IRequestHandler<DeleteCourseEnrollmentCommand, ResponseModel>
{
    private readonly ICourseEnrollmentRepository repository;
    private IMapper mapper;
    private ILogger<DeleteCourseEnrollmentCommandHandler> logger;
    public DeleteCourseEnrollmentCommandHandler(ICourseEnrollmentRepository repository, IMapper mapper, ILogger<DeleteCourseEnrollmentCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(DeleteCourseEnrollmentCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var courseEnrollment = mapper.Map<CourseEnrollmentEntity>(request);
        var courseEnrollmentToUpdate = await repository.GetAsync(request.Id);
        if (courseEnrollmentToUpdate == null)
        {
            throw new CourseEnrollmentNotFoundException(nameof(request), request.Id);
        }
        var generateOrg = await repository.DeleteAsync(courseEnrollment);
        if (generateOrg.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateOrg;
            logger.LogInformation(($"Course Enrollment {generateOrg} deleted successfully."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}
