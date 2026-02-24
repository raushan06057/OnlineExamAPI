namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IExamAttemptRepository:IAsyncRepository<ExamAttemptEntity>
{
    Task<bool> IsExamAttemptExistsAsync(long studentId, long examId);
}
