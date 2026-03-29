namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class CreateStudentExamSubmitCommandHandler : IRequestHandler<CreateStudentExamSubmitCommand, ResponseModel>
{
    private readonly IExamRepository repository;
    private readonly IUserRepository userRepository;
    private readonly IEmailService emailService;
    public CreateStudentExamSubmitCommandHandler(IExamRepository repository, IUserRepository userRepository, IEmailService emailService)
    {
        this.repository = repository;
        this.userRepository = userRepository;
        this.emailService = emailService;
    }
    public async Task<ResponseModel> Handle(CreateStudentExamSubmitCommand request, CancellationToken cancellationToken)
    {
        var response = new ResponseModel();
        response.Success = true;
        int marksObtained = 0;
        int totalMarks = 0;
        int passingMarks = 0;
        string? userEmail = null;
        string userName = string.Empty;
        response.Data = await repository.GetStudentExamResultsByIdAsync(request.CreatedBy, request.ExamId);
        try
        {
            if (response.Data != null)
            {
                var erType = response.Data.GetType();
                var pMarksObtained = erType.GetProperty("MarksObtained");
                var pTotalMarks = erType.GetProperty("TotalMarks");
                var pPassingMarks = erType.GetProperty("PassingMarks");
                if (pMarksObtained != null)
                    marksObtained = Convert.ToInt32(pMarksObtained.GetValue(response.Data) ?? 0);

                if (pTotalMarks != null)
                    totalMarks = Convert.ToInt32(pTotalMarks.GetValue(response.Data) ?? 0);

                if (pPassingMarks != null)
                    passingMarks = Convert.ToInt32(pPassingMarks.GetValue(response.Data) ?? 0);
            }
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
                    bool passed = marksObtained >= passingMarks;
                    string html = "<p>Hello {{UserName}}</p><p>Marks: {{MarksObtained}} / {{TotalMarks}}</p><p>Status: {{Passed}}</p>";

                    html = html.Replace("{{UserName}}", WebUtility.HtmlEncode(userName ?? string.Empty))
                               .Replace("{{MarksObtained}}", marksObtained.ToString())
                               .Replace("{{TotalMarks}}", totalMarks.ToString())
                               .Replace("{{Passed}}", passed ? "Passed" : "Failed")
                               .Replace("{{PassedClass}}", passed ? "passed" : "failed");

                    var subject = $"Exam Result - {(passed ? "Passed" : "Failed")}";
                    await emailService.SendEmailAsync("toEmail", subject, html);
                }
            }
        }
        catch (Exception)
        {
        }
        return response;
    }
}