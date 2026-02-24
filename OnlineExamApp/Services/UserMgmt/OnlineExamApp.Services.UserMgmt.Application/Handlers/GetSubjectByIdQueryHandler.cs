namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, ResponseModel>
{
    private ISubjectRepository repository;
    public GetSubjectByIdQueryHandler(ISubjectRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var subjects = await repository.GetSubjectByIdAsync(request.SubjectId);
        responseModel.Success = true;
        responseModel.Data = subjects;
        return responseModel;
    }
}
