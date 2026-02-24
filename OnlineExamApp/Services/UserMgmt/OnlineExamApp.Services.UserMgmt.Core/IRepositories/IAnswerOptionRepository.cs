namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IAnswerOptionRepository:IAsyncRepository<AnswerOptionEntity>
{
    Task<bool> IsIAnswerOptionExistsAsync(long questionId,string ansOpt);
}
