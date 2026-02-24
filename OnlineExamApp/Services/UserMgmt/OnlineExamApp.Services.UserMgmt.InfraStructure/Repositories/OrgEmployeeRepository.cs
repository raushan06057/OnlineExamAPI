namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class OrgEmployeeRepository : RepositoryBase<OrgEmployeeEntity>, IOrgEmployeeRepository
{
    public OrgEmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsEmailExistsAsync(string email)
    {
        var emailExists = await context.OrgEmployees.AnyAsync(mod => mod.EmailAddress == email);
        return emailExists;
    }
}
