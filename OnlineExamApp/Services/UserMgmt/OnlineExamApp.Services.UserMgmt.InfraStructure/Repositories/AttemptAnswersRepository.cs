
namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class AttemptAnswersRepository : RepositoryBase<AttemptAnswerEntity>, IAttemptAnswersRepository
{
    public AttemptAnswersRepository(ApplicationDbContext context) : base(context)
    {
    }
}
