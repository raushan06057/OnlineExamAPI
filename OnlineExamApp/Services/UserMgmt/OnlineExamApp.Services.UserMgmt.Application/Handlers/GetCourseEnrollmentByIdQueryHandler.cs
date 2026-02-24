namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetCourseEnrollmentByIdQueryHandler : IRequestHandler<GetCourseEnrollmentByIdQuery, ResponseModel>
{
    private readonly ICourseEnrollmentRepository repository;

    public GetCourseEnrollmentByIdQueryHandler(ICourseEnrollmentRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetCourseEnrollmentByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var enrollment = await repository.GetQueryAsync().Include(mod=>mod.Course).FirstOrDefaultAsync(mod=>mod.Id==request.EnrollmentId);
        var result = new
        {
            enrollment.Id,
            enrollment.StudentId,
            enrollment.EnrollmentDate,
            enrollment.CompletionDate,
            enrollment.Grade,
            enrollment.CourseId,
            OrganizationId = enrollment.Course?.OrganizationId ?? 0L
        };
        if (enrollment == null)
        {
            throw new CourseEnrollmentNotFoundException(nameof(request), request.EnrollmentId);
        }

        responseModel.Success = true;
        responseModel.Data = result;
        return responseModel;
    }
}