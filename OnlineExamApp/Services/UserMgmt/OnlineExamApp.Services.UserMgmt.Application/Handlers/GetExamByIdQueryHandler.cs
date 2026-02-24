namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetExamByIdQueryHandler : IRequestHandler<GetExamByIdQuery, ResponseModel>
{
    private readonly IExamRepository repository;
    private readonly ISubjectRepository subjectRepository;
    private readonly IOrgDepartmentRepository orgDepartmentRepository;

    public GetExamByIdQueryHandler(IExamRepository repository,
        IOrgDepartmentRepository orgDepartmentRepository,
        ISubjectRepository subjectRepository)
    {
        this.repository = repository;
        this.orgDepartmentRepository = orgDepartmentRepository;
        this.subjectRepository = subjectRepository;
    }

    public async Task<ResponseModel> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var exam = await repository.GetAsync(request.ExamId);
        if (exam == null)
        {
            throw new StudentNotFoundException(nameof(request), request.ExamId);
        }
        var orgDepartments = await orgDepartmentRepository.GetQueryAsync()
            .Where(mod=>mod.OrganizationId==exam.OrganizationId).ToListAsync();
        responseModel.Success = true;
        responseModel.Data = exam;
        return responseModel;
    }
}