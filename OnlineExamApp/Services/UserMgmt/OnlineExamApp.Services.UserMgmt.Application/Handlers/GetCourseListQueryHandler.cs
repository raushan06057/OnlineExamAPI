namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, ResponseModel>
{
    private readonly ICourseRepository repository;

    public GetCourseListQueryHandler(ICourseRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var courses = await repository.GetCoursesWithOrgAsync();

        responseModel.Success = true;
        responseModel.Data = courses;
        return responseModel;
    }
}