namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IOrgEmployeeRepository : IAsyncRepository<OrgEmployeeEntity>
{
    Task<bool> IsEmailExistsAsync(string email);
}
