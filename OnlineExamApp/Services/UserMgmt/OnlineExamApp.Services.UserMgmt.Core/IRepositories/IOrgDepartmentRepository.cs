namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IOrgDepartmentRepository : IAsyncRepository<OrgDepartmentEntity>
{
    Task<bool> IsNameExistsAsync(string name, long OrganizationId);
    Task<dynamic> GetDeptWithOrgAsync();
}
