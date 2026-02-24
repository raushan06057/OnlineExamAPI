namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class AnswerRepository : RepositoryBase<AnswerEntity>, IAnswerRepository
{
    public AnswerRepository(ApplicationDbContext context) : base(context)
    {
    }
}
