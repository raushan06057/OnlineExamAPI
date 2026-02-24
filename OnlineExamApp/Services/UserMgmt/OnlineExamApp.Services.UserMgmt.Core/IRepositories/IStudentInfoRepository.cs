namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IStudentInfoRepository : IAsyncRepository<StudentInfoEntity>
{
    Task<bool> IsStudentMobileExistsAsync(string mobile);
    Task<bool> IsStudentEmailExistsAsync(string email);
    Task<dynamic> GetStudentsWithDeptListAsync();
}