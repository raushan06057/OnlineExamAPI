namespace OnlineExamApp.Services.UserMgmt.Core.Entities;
[Table(CommonFields.OrgEmployees)]
public class OrgEmployeeEntity : BasicInfoEntity
{
    public string? EmailAddress { get; set; }
    public long? OrganizationId { get; set; }
    public DateTime? HireDate { get; set; }
    // Navigation property for the Role
    public string EmployeeRoleId {  get; set; }
    public ApplicationRole EmployeeRole { get; set; }

    // Navigation property for the department
    public long DepartmentId { get; set; }
    public OrgDepartmentEntity Department { get; set; }
}
