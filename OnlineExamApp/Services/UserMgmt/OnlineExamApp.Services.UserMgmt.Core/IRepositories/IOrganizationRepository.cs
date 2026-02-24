namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IOrganizationRepository : IAsyncRepository<OrganizationEntity>
{
    Task<bool> IsNameExistsAsync(string name);
}