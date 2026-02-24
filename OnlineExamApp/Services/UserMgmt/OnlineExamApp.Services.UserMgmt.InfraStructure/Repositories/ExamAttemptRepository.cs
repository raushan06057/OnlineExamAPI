namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class ExamAttemptRepository : RepositoryBase<ExamAttemptEntity>, IExamAttemptRepository
{
    public ExamAttemptRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsExamAttemptExistsAsync(long studentId, long examId)
    {
        var isExamAttemptExists = await context.ExamAttempts.AnyAsync(mod=>mod.StudentId==studentId && mod.ExamId==examId); 
        return isExamAttemptExists;
    }
}
