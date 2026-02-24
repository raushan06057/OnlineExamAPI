namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface ICourseRepository : IAsyncRepository<CourseEntity>
{
    Task<bool> IsCourseExistsAsync(string name);
    Task<dynamic> GetCoursesWithOrgAsync();
}