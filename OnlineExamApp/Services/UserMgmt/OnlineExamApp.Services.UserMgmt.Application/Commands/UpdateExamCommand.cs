namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class UpdateExamCommand : IRequest<ResponseModel>
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DurationInMinutes { get; set; }
    public int OrganizationId { get; set; }
    public int DepartmentId { get; set; }
    public long CourseId { get; set; }
    public long SubjectId { get; set; }
    public int TotalMarks { get; set; }
    public int PassingMarks { get; set; }
    public bool IsScheduled { get; set; }
}
