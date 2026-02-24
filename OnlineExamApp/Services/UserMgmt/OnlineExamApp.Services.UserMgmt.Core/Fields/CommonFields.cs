namespace OnlineExamApp.Services.UserMgmt.Core.Fields;

public class CommonFields
{
    public const string ApplicationUserDBConnection = "ApplicationUserDBConnection";
    public const string Organization = "Organization";
    public const string OrgEmployees = "OrgEmployees";
    public const string StudentInfo = "StudentInfo";
    public const string CourseEnrollments = "CourseEnrollments";
    public const string GuardianInfo = "GuardianInfo";
    public const string Courses = "Courses";
    public const string JwtSettings = "JwtSettings";
    public const string SecretKey = "SecretKey";
    public const string ExpiresIn = "ExpiresIn";
    public const string Login = "Login";
    public const string Authorization = "Authorization";
    public const string UserId = "UserId";
    public const string RoleId = "RoleId";
    public const string JwtColonKey = "Jwt:Key";
    public const string JwtColonIssuer = "Jwt:Issuer";
    public const string JwtColonAudience = "Jwt:Audience";
    public const string ID = "Id";
    public const string GetById = "GetById";
    public const string GetByOrgId = "GetByOrgId";
    public const string GetByRoleId = "GetByRoleId";
    public const string GetByDeptId = "GetByDeptId";
    public const string GetByExamId = "GetByExamId";
    public const string GetUpComingExams = "GetUpComingExams";
    public const string Header = "Header";
    public const string CORSPolicy = "CORSPolicy";
    public const string OrganizationId = "OrganizationId";

    //Controller Names
    public const string Organizations = "Organizations";

    //Action Names
    public const string Get = "get";
    public const string Post = "post";
    public const string Put = "put";
    public const string Delete = "delete";

    //Roles
    public const string Admin= "admin";
    public const string Student = "Student";
    //DefaultPwd
    public const string StudentPwd = "DefaultPwd:StudentPwd";
}
