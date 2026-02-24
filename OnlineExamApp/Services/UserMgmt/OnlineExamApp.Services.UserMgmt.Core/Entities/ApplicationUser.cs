namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class ApplicationUser : IdentityUser
{
    public string? Pwd { get; set; } // Note: Storing passwords in plain text is insecure. Use Identity's built-in password hashing.
    public string? Role { get; set; } // This might not be necessary if you're using Identity's role system correctly.

    // Navigation property for the organization
    public long OrganizationId { get; set; }
    public OrganizationEntity Organization { get; set; }

    // Navigation property for the department
    public long DepartmentId { get; set; }
    public OrgDepartmentEntity Department { get; set; }
}