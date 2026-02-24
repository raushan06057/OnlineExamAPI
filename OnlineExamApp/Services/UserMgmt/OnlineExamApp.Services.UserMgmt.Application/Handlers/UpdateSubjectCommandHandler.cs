namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, ResponseModel>
{
    private readonly ISubjectRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateSubjectCommandHandler> logger;
    public UpdateSubjectCommandHandler(ISubjectRepository repository,IMapper mapper,ILogger<UpdateSubjectCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var subjectEntity = mapper.Map<SubjectEntity>(request);

        var subToUpdate = await repository.GetAsync(request.Id);
        if (subToUpdate == null)
        {
            throw new OrganizationDeptNotFoundException(nameof(request), request.Id);
        }
        var generateOrg = await repository.UpdateAsync(subjectEntity);
        if (generateOrg.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = generateOrg;
            logger.LogInformation(($"Subject {generateOrg} updated successfully."));
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}