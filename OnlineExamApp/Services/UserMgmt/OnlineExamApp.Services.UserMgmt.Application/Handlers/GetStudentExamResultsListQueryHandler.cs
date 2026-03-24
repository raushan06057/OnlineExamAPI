namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;
public class GetStudentExamResultsListQueryHandler : IRequestHandler<GetStudentExamResultsListQuery, ResponseModel>
{
    private readonly IExamRepository repository;
    public GetStudentExamResultsListQueryHandler(IExamRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetStudentExamResultsListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        responseModel.Success = true;
        responseModel.Data = await repository.GetStudentExamResultsAsync(request.StudentId);
        return responseModel;
    }
}
