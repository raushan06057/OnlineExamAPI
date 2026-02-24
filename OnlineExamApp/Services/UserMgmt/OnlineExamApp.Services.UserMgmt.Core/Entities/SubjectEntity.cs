namespace OnlineExamApp.Services.UserMgmt.Core.Entities;
[Table("Subject")]
public class SubjectEntity : BaseEntity
{
    public string? Name { get; set; }
    [ForeignKey("Course")]
    public long? CourseId { get; set; }
    public CourseEntity Course { get; set; }
    [ForeignKey("Department")]
    public long DepartmentId { get; set; }
    public OrgDepartmentEntity Department { get; set; }
}