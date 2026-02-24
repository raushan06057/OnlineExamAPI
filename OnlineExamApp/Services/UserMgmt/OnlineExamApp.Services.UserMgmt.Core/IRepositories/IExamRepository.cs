namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IExamRepository : IAsyncRepository<ExamEntity>
{
    Task<bool> IsExamExistsAsync(string name, long organizationId);
    Task<dynamic> GetExamsAsync();
    Task<dynamic> GetStudentExamSchedules(string userId);
}