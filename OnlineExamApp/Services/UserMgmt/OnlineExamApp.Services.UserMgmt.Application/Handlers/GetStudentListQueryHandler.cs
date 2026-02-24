namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetStudentListQueryHandler : IRequestHandler<GetStudentListQuery, ResponseModel>
{
    private readonly IStudentInfoRepository repository;

    public GetStudentListQueryHandler(IStudentInfoRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var students = await repository.GetStudentsWithDeptListAsync();
        responseModel.Success = true;
        responseModel.Data = students;
        return responseModel;
    }
}