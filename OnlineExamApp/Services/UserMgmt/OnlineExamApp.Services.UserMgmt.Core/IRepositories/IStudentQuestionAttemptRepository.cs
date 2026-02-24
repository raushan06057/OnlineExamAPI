namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IStudentQuestionAttemptRepository:IAsyncRepository<QuestionAttemptEntity>
{
    Task<bool> HasQuestionAttemptAsync(QuestionAttemptEntity questionAttempt);
}
