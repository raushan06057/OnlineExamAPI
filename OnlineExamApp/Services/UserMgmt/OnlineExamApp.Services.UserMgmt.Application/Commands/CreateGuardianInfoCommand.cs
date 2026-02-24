namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateGuardianInfoCommand : IRequest<ResponseModel>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Relationship { get; set; }
    public long OrganizationId { get; set; }
    public long? StudentId { get; set; }
}