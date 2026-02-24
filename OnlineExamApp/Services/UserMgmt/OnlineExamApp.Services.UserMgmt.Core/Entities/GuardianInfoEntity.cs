namespace OnlineExamApp.Services.UserMgmt.Core.Entities;
[Table(CommonFields.GuardianInfo)]
public class GuardianInfoEntity:BasicInfoEntity
{
    public string Relationship { get; set; }
    // List of students associated with this guardian
    public ICollection<StudentInfoEntity> Students { get; set; }
    public long OrganizationId { get; set; }
    [ForeignKey("OrganizationId")]
    public OrganizationEntity Organization { get; set; }
    // Constructor to initialize collections (if needed)
    public GuardianInfoEntity()
    {
        Students = new List<StudentInfoEntity>();
    }
}