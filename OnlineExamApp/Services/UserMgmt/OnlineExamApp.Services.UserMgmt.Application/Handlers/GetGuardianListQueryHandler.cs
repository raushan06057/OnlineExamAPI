namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetGuardianListQueryHandler : IRequestHandler<GetGuardianListQuery, ResponseModel>
{
    private readonly IGuardianInfoRepository repository;

    public GetGuardianListQueryHandler(IGuardianInfoRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetGuardianListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var guardians = await repository.GetAsync();

        responseModel.Success = true;
        responseModel.Data = guardians;
        return responseModel;
    }
}