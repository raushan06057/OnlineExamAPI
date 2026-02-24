namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class OrgDepartmentRepository : RepositoryBase<OrgDepartmentEntity>, IOrgDepartmentRepository
{
    public OrgDepartmentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsNameExistsAsync(string name,long OrganizationId)
    {
        var isExist = await context.OrgDepartments.AnyAsync(mod=>mod.Name==name && mod.OrganizationId==OrganizationId);
        return isExist;
    }

    public async Task<dynamic> GetDeptWithOrgAsync()
    {
        var result = await context.OrgDepartments.Include(mod => mod.Organization)
            .Select(mod =>new
            {
                mod.Name,
                mod.Code,
                mod.Description,
                mod.Id,
                mod.OrganizationId,
                OrgName = mod.Organization.Name
            }).ToListAsync();
        return result;
    }
}