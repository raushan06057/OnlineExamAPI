namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class AnswerOptionRepository : RepositoryBase<AnswerOptionEntity>, IAnswerOptionRepository
{
    public AnswerOptionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsIAnswerOptionExistsAsync(long questionId, string ansOpt)
    {
        var isExist = await context.AnswerOptions.AnyAsync(mod=>mod.QuestionId == questionId && mod.Text==ansOpt);
        return isExist;
    }
}
