namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

[Table(CommonFields.Organization)]
public class OrganizationEntity : BaseEntity
{
    // Name of the organization
    public string Name { get; set; }

    // Description or mission statement of the organization
    public string Description { get; set; }

    // Address of the organization's headquarters
    public long HeadquartersAddressId { get; set; } // Foreign key to OrganizationAddressEntity
    public OrganizationAddressEntity HeadquartersAddress { get; set; }

    // List of departments within the organization
    public ICollection<OrgDepartmentEntity> Departments { get; set; }

    // List of employees in the organization
    public ICollection<ApplicationUser> Employees { get; set; }

    // CEO or top-level executive of the organization (optional)
    //public ApplicationUser CEO { get; set; }

    // Date when the organization was founded
    public DateTime FoundingDate { get; set; }

    // Industry or sector in which the organization operates
    public string Industry { get; set; }

    // Website URL for the organization
    public string Website { get; set; }
    public List<ExamEntity> Exams { get; set; }
    public ICollection<GuardianInfoEntity> GuardianInfos { get; set; }
    // Constructor to initialize collections (if needed)
    public OrganizationEntity()
    {
        Departments = new List<OrgDepartmentEntity>();
        Employees = new List<ApplicationUser>();
        Exams = new List<ExamEntity>();
        GuardianInfos= new List<GuardianInfoEntity>();
    }
}