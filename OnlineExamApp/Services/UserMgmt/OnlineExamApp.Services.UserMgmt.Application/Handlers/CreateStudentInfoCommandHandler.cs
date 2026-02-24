namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateStudentInfoCommandHandler : IRequestHandler<CreateStudentInfoCommand, ResponseModel>
{
    private readonly IStudentInfoRepository repository;
    private readonly IUserRepository userRepository;
    private IMapper mapper;
    private ILogger<CreateStudentInfoCommandHandler> logger;
    private IConfiguration configuration;
    private readonly IOrgDepartmentRepository orgDepartmentRepository;
    public CreateStudentInfoCommandHandler(IStudentInfoRepository repository, IMapper mapper, ILogger<CreateStudentInfoCommandHandler> logger, 
        IUserRepository userRepository, IConfiguration configuration, IOrgDepartmentRepository orgDepartmentRepository)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
        this.userRepository = userRepository;
        this.configuration = configuration;
        this.orgDepartmentRepository = orgDepartmentRepository;
    }
    public async Task<ResponseModel> Handle(CreateStudentInfoCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var isPhoneExists = await repository.IsStudentMobileExistsAsync(request.PhoneNumber);
        var isEmailExists = await repository.IsStudentEmailExistsAsync(request.EmailAddress);
        if (isPhoneExists)
        {
            throw new MobileAlreadyExistsException(nameof(request), null);
        }
        else if (isEmailExists)
        {
            throw new EmailAddressAlreadyExistsException(nameof(request), null);
        }
        else
        {
            var deptDtl = await orgDepartmentRepository.GetAsync(request.DepartmentId);
            var userModel = new ApplicationUser()
            {
                UserName = request.EmailAddress,
                Email = request.EmailAddress,
                Pwd = configuration[CommonFields.StudentPwd],
                Role = CommonFields.Student,
                OrganizationId=deptDtl.OrganizationId,
                DepartmentId = request.DepartmentId,
                PhoneNumber = request.PhoneNumber,
            };
            await userRepository.CreateAsync(userModel,null);
            var studentInfoDtl = mapper.Map<StudentInfoEntity>(request);
            studentInfoDtl.UserId=userModel.Id;
            var student = await repository.AddAsync(studentInfoDtl);
            if (student.Id != 0)
            {
                responseModel.Success = true;
                responseModel.Data = student;
                logger.LogInformation(($"Student details {student} saved successfully."));
                responseModel.Message = CommonResource.RecordSavedSuccessfully;
            }
        }
        return responseModel;
    }
}
