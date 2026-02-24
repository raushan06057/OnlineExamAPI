namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class GuardianInfoRepository : RepositoryBase<GuardianInfoEntity>, IGuardianInfoRepository
{
    public GuardianInfoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsGuardianInfoExistsAsync(long? studentId, long guardianInfoId)
    {
        var isCourse = await context.Guardians.AnyAsync(mod => mod.Id==guardianInfoId);
        return isCourse;
    }
}
