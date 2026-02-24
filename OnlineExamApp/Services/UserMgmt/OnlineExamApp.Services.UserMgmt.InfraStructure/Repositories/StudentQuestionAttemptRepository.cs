namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class StudentQuestionAttemptRepository : RepositoryBase<QuestionAttemptEntity>, IStudentQuestionAttemptRepository
{
    public StudentQuestionAttemptRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> HasQuestionAttemptAsync(QuestionAttemptEntity entity)
    {
        var isRecordExists = await context.QuestionAttempts.AnyAsync(mod => mod.StudentInfoId == entity.StudentInfoId
        && mod.QuestionId == entity.QuestionId && mod.ExamId == entity.ExamId);
        return isRecordExists;
    }
}
