namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, ResponseModel>
{
    private readonly IStudentInfoRepository repository;
    private readonly IOrgDepartmentRepository departmentRepository;

    public GetStudentByIdQueryHandler(IStudentInfoRepository repository, IOrgDepartmentRepository departmentRepository)
    {
        this.repository = repository;
        this.departmentRepository = departmentRepository;
    }

    public async Task<ResponseModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var student = await repository.GetQueryAsync().Join(
            departmentRepository.GetQueryAsync(),
            student => student.DepartmentId,
            dept => dept.Id,
            (student, dept) => new
            {
                student.Id,
                student.FirstName,
                student.LastName,
                student.MiddleName,
                student.Address,
                student.EmailAddress,
                student.PhoneNumber,
                student.DateOfBirth,
                student.GuardianId,
                DepartmentId = dept.Id,
                DeptName = dept.Name,
                OrganizationId = dept.OrganizationId
            }
        ).FirstOrDefaultAsync(s => s.Id == request.StudentId);
        if (student == null)
        {
            throw new StudentNotFoundException(nameof(request), request.StudentId);
        }
      
        responseModel.Success = true;
        responseModel.Data = student;
        return responseModel;
    }
}