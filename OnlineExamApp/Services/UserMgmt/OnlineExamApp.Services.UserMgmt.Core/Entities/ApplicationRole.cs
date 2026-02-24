namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class ApplicationRole : IdentityRole
{
    public long? OrganizationId { get; set; }
}
