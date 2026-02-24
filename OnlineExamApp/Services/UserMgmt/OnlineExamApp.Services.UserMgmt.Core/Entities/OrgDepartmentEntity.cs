namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class OrgDepartmentEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Foreign key to OrganizationEntity
    public long OrganizationId { get; set; }
    public OrganizationEntity Organization { get; set; }

    // List of employees in this department
    public ICollection<ApplicationUser> UserList { get; set; }
    public ICollection<OrgEmployeeEntity> Employees { get; set; }
    // List of students in this department
    public ICollection<StudentInfoEntity> Students { get; set; }
    public ICollection<SubjectEntity> Subjects { get; set; }
    // Constructor to initialize collections (if needed)
    public OrgDepartmentEntity()
    {
        UserList = new List<ApplicationUser>();
        Employees = new List<OrgEmployeeEntity>();
        Students = new List<StudentInfoEntity>();
        Subjects = new List<SubjectEntity>();
    }
}