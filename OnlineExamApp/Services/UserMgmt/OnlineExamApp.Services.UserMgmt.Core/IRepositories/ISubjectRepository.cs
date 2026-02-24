namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface ISubjectRepository : IAsyncRepository<SubjectEntity>
{
    Task<bool> IsSubjectExistsAsync(string name, long courseId);
    Task<dynamic> GetSubjectsAsync();
    Task<dynamic?> GetSubjectByIdAsync(long subjectId);
}