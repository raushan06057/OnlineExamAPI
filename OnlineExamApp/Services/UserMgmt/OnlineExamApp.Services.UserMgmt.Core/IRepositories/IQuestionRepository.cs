namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IQuestionRepository : IAsyncRepository<QuestionEntity>
{
    Task<bool> IsQuestionExistsAsync(long examId,string question);
    Task<dynamic> GetQuestionsAsync();
}
