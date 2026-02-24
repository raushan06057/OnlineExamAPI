namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IGuardianInfoRepository:IAsyncRepository<GuardianInfoEntity>
{
    Task<bool> IsGuardianInfoExistsAsync(long? studentId,long guardianInfoId);
}