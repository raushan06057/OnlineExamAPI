namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateStudentExamGraphCommandHandler : IRequestHandler<CreateStudentExamGraphCommand, ResponseModel>
{
    private readonly IExamRepository repository;
    private readonly IUserRepository userRepository;
    private readonly IAiInsightsService insightsService;
    public CreateStudentExamGraphCommandHandler(IExamRepository repository, IUserRepository userRepository, IAiInsightsService insightsService)
    {
        this.repository = repository;
        this.userRepository = userRepository;
        this.insightsService = insightsService;
    }
    public async Task<ResponseModel> Handle(CreateStudentExamGraphCommand request, CancellationToken cancellationToken)
    {
        var response = new ResponseModel();
        response.Success = true;
        string userName = string.Empty;
        var result = await repository.GetStudentExamResultsByIdAsync(request.CreatedBy, request.ExamId);
        var graphDtl = await insightsService.GetChartAsync(result);
        response.Data = graphDtl;
        return response;
    }
}
