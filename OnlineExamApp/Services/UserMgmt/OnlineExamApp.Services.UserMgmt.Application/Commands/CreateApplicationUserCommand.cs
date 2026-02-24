namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateApplicationUserCommand : IRequest<ResponseModel>
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Pwd { get; set; }
    public string? Role { get; set; }
    public long? OrganizationId { get; set; }
    public long? DepartmentId { get; set; }
    public string? PhoneNumber { get; set; }
    public List<Claim> ClaimList { get; set; }
    public CreateApplicationUserCommand()
    {
        ClaimList = new();
    }
}   
