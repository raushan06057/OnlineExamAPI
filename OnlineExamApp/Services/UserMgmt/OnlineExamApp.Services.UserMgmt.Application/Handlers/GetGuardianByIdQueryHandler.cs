namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetGuardianByIdQueryHandler : IRequestHandler<GetGuardianByIdQuery, ResponseModel>
{
    private readonly IGuardianInfoRepository repository;

    public GetGuardianByIdQueryHandler(IGuardianInfoRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetGuardianByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var guardian = await repository.GetAsync(request.GuardianId);

        if (guardian == null)
        {
            throw new GuardianNotFoundException(nameof(request), request.GuardianId);
        }

        responseModel.Success = true;
        responseModel.Data = guardian;
        return responseModel;
    }
}