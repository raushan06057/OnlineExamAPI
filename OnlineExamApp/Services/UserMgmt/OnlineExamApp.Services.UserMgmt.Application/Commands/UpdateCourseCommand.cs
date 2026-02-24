namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class UpdateCourseCommand : IRequest<ResponseModel>
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Credits { get; set; }
    public long OrganizationId { get; set; }
}
