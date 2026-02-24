namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class QuestionRepository : RepositoryBase<QuestionEntity>, IQuestionRepository
{
    public QuestionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsQuestionExistsAsync(long examId, string question)
    {
        var isQuestExist = await context.Questions.AnyAsync(mod => mod.ExamId == examId && mod.Text == question);
        return isQuestExist;
    }

    public async Task<dynamic> GetQuestionsAsync()
    {
        var result = await context.Questions.Include(mod => mod.Exam)
            .ThenInclude(org => org.Organization).
            Select(mod => new
            {
                mod.Id,
                mod.Text,
                mod.Marks,
                TypeName = Convert.ToString(mod.Type),
                mod.ExamId,
                ExamName = mod.Exam.Title,
                OrgId = mod.Exam.OrganizationId,
                OrgName = mod.Exam.Organization.Name
            }).ToListAsync();
        return result;
    }
}
