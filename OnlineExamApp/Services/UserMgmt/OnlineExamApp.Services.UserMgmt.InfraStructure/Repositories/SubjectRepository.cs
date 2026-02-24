namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class SubjectRepository : RepositoryBase<SubjectEntity>, ISubjectRepository
{
    public SubjectRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<dynamic> GetSubjectsAsync()
    {
        var result = await context.Subjects.Include(mod => mod.Course)
            .Include(mod => mod.Department).ThenInclude(org => org.Organization).Select(mod => new
            {
                mod.Id,
                mod.Name,
                mod.CourseId,
                CourseName = mod.Course.Title,
                mod.DepartmentId,
                DepartmentName = mod.Department.Name,
                mod.Course.OrganizationId,
                OrganizationName = mod.Course.Organization.Name
            }).ToListAsync();

        return result;
    }
    public async Task<dynamic?> GetSubjectByIdAsync(long subjectId)
    {
        var result = await context.Subjects.Include(mod => mod.Course)
            .Include(mod => mod.Department).ThenInclude(org => org.Organization).Select(mod => new
            {
                mod.Id,
                mod.Name,
                mod.CourseId,
                CourseName = mod.Course.Title,
                mod.DepartmentId,
                DepartmentName = mod.Department.Name,
                mod.Course.OrganizationId,
                OrganizationName = mod.Course.Organization.Name
            }).FirstOrDefaultAsync(mod => mod.Id == subjectId);
        return result;
    }
    public async Task<bool> IsSubjectExistsAsync(string name, long courseId)
    {
        return await context.Subjects.AnyAsync(mod => mod.Name == name && mod.CourseId == courseId);
    }
}
