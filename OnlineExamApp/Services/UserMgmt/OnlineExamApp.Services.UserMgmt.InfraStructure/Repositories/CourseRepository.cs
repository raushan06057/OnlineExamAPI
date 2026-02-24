namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class CourseRepository : RepositoryBase<CourseEntity>, ICourseRepository
{
    public CourseRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsCourseExistsAsync(string name)
    {
        var isCourse = await context.Courses.AnyAsync(mod => mod.Title == name);
        return isCourse;
    }

    public async Task<dynamic> GetCoursesWithOrgAsync()
    {
        var result = await context.Courses.Include(mod => mod.Organization).Select(mod => new
        {
            mod.Id,mod.Title,mod.Description,mod.Credits,OrgName=mod.Organization.Name,
            organizationId=mod.Organization.Id
        }).ToListAsync();
        return result;
    }
}