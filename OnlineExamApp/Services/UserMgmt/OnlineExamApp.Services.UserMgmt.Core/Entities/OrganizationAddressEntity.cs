namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class OrganizationAddressEntity : BaseEntity
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }

    // Foreign key to OrganizationEntity
    public long OrganizationId { get; set; }
    public OrganizationEntity Organization { get; set; }
}