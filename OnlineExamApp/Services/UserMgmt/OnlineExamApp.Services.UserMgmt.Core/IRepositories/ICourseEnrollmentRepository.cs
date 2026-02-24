namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface ICourseEnrollmentRepository : IAsyncRepository<CourseEnrollmentEntity>
{
    Task<bool> IsCourseEnrollmentExistsAsync(long studentId,long courseId);
}
