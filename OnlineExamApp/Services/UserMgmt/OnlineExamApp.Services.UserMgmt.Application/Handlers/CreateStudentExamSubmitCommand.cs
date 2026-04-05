namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateStudentExamSubmitCommandHandler : IRequestHandler<CreateStudentExamSubmitCommand, ResponseModel>
{
    private readonly IExamRepository repository;
    private readonly IUserRepository userRepository;
    private readonly IEmailService emailService;
    private readonly IAiInsightsService insightsService;
    public CreateStudentExamSubmitCommandHandler(IExamRepository repository, IUserRepository userRepository, IEmailService emailService, IAiInsightsService insightsService)
    {
        this.repository = repository;
        this.userRepository = userRepository;
        this.emailService = emailService;
        this.insightsService = insightsService;
    }
    public async Task<ResponseModel> Handle(CreateStudentExamSubmitCommand request, CancellationToken cancellationToken)
    {
        var response = new ResponseModel();
        response.Success = true;
        string? userEmail = null;
        string userName = string.Empty;
        var result = await repository.GetStudentExamResultsByIdAsync(request.CreatedBy, request.ExamId);
        var userResp = await userRepository.GetAsync(request.CreatedBy);
        if (userResp != null && userResp.Data != null)
        {
            var userObj = userResp.Data;
            var uType = userObj.GetType();
            var pEmail = uType.GetProperty("Email");
            var pUserName = uType.GetProperty("UserName");

            if (pEmail != null)
                userEmail = pEmail.GetValue(userObj) as string;

            if (pUserName != null)
                userName = pUserName.GetValue(userObj) as string ?? string.Empty;
        }
        if (userResp != null)
        {
            if (userResp.Data != null)
            {
                bool passed = result.MarksObtained >= result.PassingMarks;
                try
                {
                    string html = "<p>Hello {{UserName}}</p><p>Marks: {{MarksObtained}} / {{TotalMarks}}</p><p>Status: {{Passed}}</p>";

                    html = html.Replace("{{UserName}}", WebUtility.HtmlEncode(userName ?? string.Empty))
                               .Replace("{{MarksObtained}}", Convert.ToString(result.MarksObtained))
                               .Replace("{{TotalMarks}}", Convert.ToString(result.TotalMarks))
                               .Replace("{{Passed}}", passed ? "Passed" : "Failed")
                               .Replace("{{PassedClass}}", passed ? "passed" : "failed");

                    var subject = $"Exam Result - {(passed ? "Passed" : "Failed")}";
                    await emailService.SendEmailAsync("toEmail", subject, html);
                }
                catch (Exception)
                {
                }
                response.ChatResponse = await insightsService.GetInsightsAsync(result);
            }
        }
        response.Data = result;
        return response;
    }
}