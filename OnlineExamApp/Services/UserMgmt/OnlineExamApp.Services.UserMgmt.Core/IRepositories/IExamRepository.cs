namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IExamRepository : IAsyncRepository<ExamEntity>
{
    Task<bool> IsExamExistsAsync(string name, long organizationId);
    Task<dynamic> GetExamsAsync(string username);
    Task<dynamic> GetStudentExamSchedules(string userId);
    Task<dynamic> GetStudentExamResultsAsync(string userId);
    Task<StudentPerformanceDto> GetStudentExamResultsByIdAsync(string userId, long examId);
}