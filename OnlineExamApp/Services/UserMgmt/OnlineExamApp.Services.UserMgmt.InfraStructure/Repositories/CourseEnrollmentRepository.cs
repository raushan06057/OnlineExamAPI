namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class CourseEnrollmentRepository : RepositoryBase<CourseEnrollmentEntity>, ICourseEnrollmentRepository
{
    public CourseEnrollmentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsCourseEnrollmentExistsAsync(long studentId, long courseId)
    {
        var isCourseEnrollment = await context.CourseEnrollments.AnyAsync(mod => mod.StudentId == studentId
        && mod.CourseId==courseId);
        return isCourseEnrollment;
    }
}
