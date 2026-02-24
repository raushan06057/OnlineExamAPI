namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class ExamRepository : RepositoryBase<ExamEntity>, IExamRepository
{
    public ExamRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsExamExistsAsync(string name,long organizationId)
    {
        var isExamExist = await context.Exams.AnyAsync(mod => mod.Title == name && mod.OrganizationId==organizationId);
        return isExamExist;
    }
    public async Task<dynamic> GetExamsAsync()
    {
        var result = await context.Exams.Include(mod => mod.Organization).Include(crs => crs.Course)
            .Include(sub => sub.Subject).Select(mod => new
            {
                mod.Id,
                mod.Title,
                mod.Description,
                mod.StartDate,
                mod.EndDate,
                mod.DurationInMinutes,
                OrgName = mod.Organization.Name,
                OrganizationId = mod.Organization.Id,
                mod.DepartmentId,
                mod.SubjectId,
                CourseName = mod.Course.Title,
                SubjectName = mod.Subject.Name,
                mod.CourseId,
                mod.TotalMarks,
                mod.PassingMarks,
                mod.IsScheduled
            }).ToListAsync();
        return result;
    }

    public async Task<dynamic> GetStudentExamSchedules(string studentId)
    {
        var result = await (from exam in context.Exams
                            join course in context.Courses
                              on exam.CourseId equals course.Id
                            join corsEnroll in context.CourseEnrollments
                               on course.Id equals corsEnroll.CourseId

                            join stud in context.StudentInfos
                                on corsEnroll.StudentId equals stud.Id
                            where stud.UserId == studentId
                            select new
                      {
                          exam.Id,
                          exam.Title,
                          exam.Description,
                          exam.StartDate,
                          exam.EndDate,
                          exam.DurationInMinutes,

                      }).ToListAsync();
        //var result = string.Empty;
        return result;
    }
}
