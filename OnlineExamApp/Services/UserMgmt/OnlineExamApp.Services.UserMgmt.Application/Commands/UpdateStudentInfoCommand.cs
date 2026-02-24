namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class UpdateStudentInfoCommand : IRequest<ResponseModel>
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public long DepartmentId { get; set; }
    public long GuardianId { get; set; }
}