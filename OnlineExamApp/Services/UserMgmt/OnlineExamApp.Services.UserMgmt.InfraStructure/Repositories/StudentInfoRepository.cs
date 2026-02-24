namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class StudentInfoRepository : RepositoryBase<StudentInfoEntity>, IStudentInfoRepository
{
    public StudentInfoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsStudentEmailExistsAsync(string email)
    {
        var isStudentEmailExists = await context.StudentInfos.AnyAsync(mod => mod.EmailAddress == email);
        return isStudentEmailExists;
    }

    public async Task<bool> IsStudentMobileExistsAsync(string mobile)
    {
        var isStudentMobileExists = await context.StudentInfos.AnyAsync(mod => mod.PhoneNumber == mobile);
        return isStudentMobileExists;
    }

    public async Task<dynamic> GetStudentsWithDeptListAsync()
    {
        var result = await context.StudentInfos.Include(mod => mod.Department)
            .Include(mod => mod.Guardian).ThenInclude(g=>g.Organization)
            .Select(mod => new
            {
                mod.Id,
                mod.FirstName,
                mod.LastName,
                mod.MiddleName,
                mod.Address,
                mod.EmailAddress,
                mod.PhoneNumber,
                DeptName = mod.Department.Name,
                DepartmentId = mod.Department.Id,
                OrganizationId= mod.Department.OrganizationId,
                GuardianName = string.Concat(mod.Guardian.FirstName,' ', mod.Guardian.MiddleName,' ', mod.Guardian.LastName),
            }).ToListAsync();
        return result;
    }
}
