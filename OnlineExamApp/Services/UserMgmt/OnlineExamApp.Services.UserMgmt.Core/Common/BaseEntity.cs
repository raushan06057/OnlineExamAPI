namespace OnlineExamApp.Services.UserMgmt.Core.Common;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public DateTime ModifiedOnUtc { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; } = false;
}
