namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, ResponseModel>
{
    private readonly ICourseRepository repository;

    public GetCourseByIdQueryHandler(ICourseRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var course = await repository.GetAsync(request.CourseId);

        if (course == null)
        {
            throw new CourseNotFoundException(nameof(request), request.CourseId);
        }

        responseModel.Success = true;
        responseModel.Data = course;
        return responseModel;
    }
}