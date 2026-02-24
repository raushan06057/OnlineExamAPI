namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateCourseCommand : IRequest<ResponseModel>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Credits { get; set; }
    public long OrganizationId { get; set; }
    public string? CreatedBy { get; set; }
}