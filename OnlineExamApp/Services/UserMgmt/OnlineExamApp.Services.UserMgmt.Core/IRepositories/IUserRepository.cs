namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IUserRepository : IAsyncRepository<ApplicationUser>
{
    Task<ResponseModel> CreateAsync(ApplicationUser user, List<Claim> claims);
    Task<ResponseModel> GetAsync(ApplicationUser user);
    Task<ResponseModel> GetAsync(string userId);
    Task<ResponseModel> LoginAsync(string username,string password);
    Task<ResponseModel> UpdateAsync(ApplicationUser user, List<Claim> claims);
}