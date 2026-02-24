namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class OrganizationRepository : RepositoryBase<OrganizationEntity>, IOrganizationRepository
{
    public OrganizationRepository(ApplicationDbContext context) : base(context)
    {
    }
    public async Task<bool> IsNameExistsAsync(string name)
    {
        return await context.Organizations.AnyAsync(mod => mod.Name == name);
    }
}