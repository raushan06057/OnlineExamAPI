
namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateCourseEnrollmentCommandHandler : IRequestHandler<UpdateCourseEnrollmentCommand, ResponseModel>
{
    private readonly ICourseEnrollmentRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateCourseEnrollmentCommandHandler> logger;
    public UpdateCourseEnrollmentCommandHandler(ICourseEnrollmentRepository repository, IMapper mapper, ILogger<UpdateCourseEnrollmentCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(UpdateCourseEnrollmentCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var courseEnrollment = mapper.Map<CourseEnrollmentEntity>(request);
        var courseEnrollmentToUpdate = await repository.GetAsync(request.Id);
        if (courseEnrollmentToUpdate == null)
        {
            throw new CourseEnrollmentNotFoundException(nameof(request), request.Id);
        }
        var generateOrg = await repository.UpdateAsync(courseEnrollment);
        if (generateOrg.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateOrg;
            logger.LogInformation(($"Course Enrollment {generateOrg} successfully updated."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}
