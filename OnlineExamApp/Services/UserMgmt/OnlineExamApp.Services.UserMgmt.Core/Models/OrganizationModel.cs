namespace OnlineExamApp.Services.UserMgmt.Core.Models;

public class OrganizationModel : BaseEntity
{
    // Name of the organization
    public string? Name { get; set; }

    // Description or mission statement of the organization
    public string? Description { get; set; }

    // Address of the organization's headquarters
    public OrganizationAddressEntity? HeadquartersAddress { get; set; }

    // CEO or top-level executive of the organization
    public ApplicationUser CEO { get; set; }

    // Date when the organization was founded
    public DateTime FoundingDate { get; set; }

    // Industry or sector in which the organization operates
    public string? Industry { get; set; }

    // Website URL for the organization
    public string? Website { get; set; }
}