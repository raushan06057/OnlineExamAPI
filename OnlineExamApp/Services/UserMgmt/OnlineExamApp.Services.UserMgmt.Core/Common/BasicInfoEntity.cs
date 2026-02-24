namespace OnlineExamApp.Services.UserMgmt.Core.Common;

public abstract class BasicInfoEntity : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
}