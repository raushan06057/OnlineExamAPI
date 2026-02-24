namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class UpdateOrgEmployeeCommand:IRequest<ResponseModel>
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? EmailAddress { get; set; }
    public long? OrganizationId { get; set; }
    public DateTime? HireDate { get; set; }
    public string? EmployeeRoleId { get; set; }
    public long DepartmentId { get; set; }
}
