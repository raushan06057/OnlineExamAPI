namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetSubjectListQueryHandler : IRequestHandler<GetSubjectListQuery, ResponseModel>
{
    private readonly ISubjectRepository repository;
    public GetSubjectListQueryHandler(ISubjectRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var subjects = await repository.GetSubjectsAsync();
        responseModel.Success = true;
        responseModel.Data = subjects;
        return responseModel;
    }
}
