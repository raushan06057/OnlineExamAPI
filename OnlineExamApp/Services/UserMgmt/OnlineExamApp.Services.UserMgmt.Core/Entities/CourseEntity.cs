namespace OnlineExamApp.Services.UserMgmt.Core.Entities;
[Table(CommonFields.Courses)]
public class CourseEntity : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Credits { get; set; }
    [ForeignKey("Organization")]
    public long OrganizationId { get; set; }
    public OrganizationEntity Organization { get; set; }
    // List of enrollments in this course
    public ICollection<CourseEnrollmentEntity> Enrollments { get; set; }
    public ICollection<SubjectEntity> Subjects { get; set; }
    public CourseEntity()
    {
        Enrollments = new List<CourseEnrollmentEntity>();
        Subjects = new List<SubjectEntity>();
    }
}
