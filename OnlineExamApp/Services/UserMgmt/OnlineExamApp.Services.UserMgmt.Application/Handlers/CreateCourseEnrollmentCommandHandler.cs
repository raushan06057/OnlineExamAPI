
namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateCourseEnrollmentCommandHandler : IRequestHandler<CreateCourseEnrollmentCommand, ResponseModel>
{
    private readonly ICourseEnrollmentRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CreateCourseEnrollmentCommandHandler> logger;
    public CreateCourseEnrollmentCommandHandler(ICourseEnrollmentRepository repository, IMapper mapper, ILogger<CreateCourseEnrollmentCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(CreateCourseEnrollmentCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var courseEnrollment = mapper.Map<CourseEnrollmentEntity>(request);
        var isExists = await repository.IsCourseEnrollmentExistsAsync(request.StudentId, request.CourseId);
        if (isExists)
        {
            throw new CourseEnrollmentAlreadyExistsException(nameof(request), null);
        }
        else
        {
            var generateOrg = await repository.AddAsync(courseEnrollment);
            if (generateOrg.Id != 0)
            {
                responseModel.Success = true;
                responseModel.Data = generateOrg;
                logger.LogInformation(($"Course Enrollment {generateOrg} successfully created."));
                responseModel.Message = CommonResource.RecordSavedSuccessfully;
            }
        }

        return responseModel;
    }
}
