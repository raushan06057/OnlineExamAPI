namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly UserManager<ApplicationUser> userManager;
    public RoleRepository(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
    }
    public async Task<ResponseModel> CreateAsync(ApplicationRole role)
    {
        ResponseModel responseModel = new();
        //var existingRole = await roleManager.RoleExistsAsync(role.Name);
        var existingRole = await roleManager.Roles.AnyAsync(mod=>mod.Name== role.Name && mod.OrganizationId==role.OrganizationId);
        if (existingRole)
        {
            responseModel.Success = false;
            responseModel.Message = CommonResource.RecordAlreadyExists;
            return responseModel;
        }
        var result = await roleManager.CreateAsync(role);
        if(result.Succeeded)
        {
            responseModel.Success=true;
            responseModel.Message=CommonResource.RecordSavedSuccessfully;
            responseModel.Data = role;
        }
        return responseModel;
    }

    public async Task<ResponseModel> DeleteAsync(ApplicationRole role)
    {
        ResponseModel responseModel = new();
        //var existingRole = await roleManager.FindByIdAsync(role.Id);
        //if (role == null)
        //{
        //    responseModel.Success = false;
        //    responseModel.Data = CommonResource.RecordDidNotFind;
        //    return responseModel;
        //}
        var result = await roleManager.DeleteAsync(role);
        if (result.Succeeded)
        {
            responseModel.Success = true;
            responseModel.Message = CommonResource.RecordDeletedSuccessfully;
        }
        else
        {
            responseModel.Success = false;
            responseModel.Message = CommonResource.RecordDidNotFind;
        }
        return responseModel;
    }

    public async Task<ResponseModel> GetAsync(ApplicationRole role)
    {
        ResponseModel responseModel = new();
        responseModel.Success = true;
        responseModel.Data = await roleManager.FindByIdAsync(role.Id);
        return responseModel;
    }

    public async Task<ResponseModel> GetAsync()
    {
        ResponseModel responseModel = new();
        responseModel.Success = true;
        responseModel.Data=await roleManager.Roles.ToListAsync();
        return responseModel;
    }

    public async Task<ResponseModel> GetAsync(long organizationId)
    {
        ResponseModel responseModel = new();
        responseModel.Success = true;
        var roles = await roleManager.Roles.Where(mod=>mod.OrganizationId==organizationId).ToListAsync();
        responseModel.Data = roles;
        return responseModel;
    }

    public async Task<ResponseModel> GetAsync(string id)
    {
        ResponseModel responseModel = new();
        responseModel.Success = true;
        var roles = await roleManager.Roles.Where(mod => mod.Id == id).ToListAsync();
        responseModel.Data = roles;
        return responseModel;
    }

    public async Task<ResponseModel> UpdateAsync(ApplicationRole role)
    {
        ResponseModel responseModel = new();
        if (string.IsNullOrWhiteSpace(role.Id) || string.IsNullOrWhiteSpace(role.Name))
        {
            responseModel.Success=false;
            responseModel.Message=CommonResource.RoleIDandnewrolenamearerequired;
            return responseModel;
        }

        var existingRole = await roleManager.FindByIdAsync(role.Id);
        if (existingRole == null)
        {
            responseModel.Success = false;
            responseModel.Message = CommonResource.RoleNotFound;
            return responseModel;
        }
        //var existingRoleWithNewName = await roleManager.FindByNameAsync(role.Name);
        var existingRoleWithNewName = await roleManager.Roles.AnyAsync(mod=>mod.Name==role.Name && mod.OrganizationId==role.OrganizationId);
        if (existingRoleWithNewName)
        {
            responseModel.Success = false;
            responseModel.Message = CommonResource.RoleWithThisNameAlreadyExists;
            return responseModel;
        }
        existingRole.Name = role.Name;
        var result = await roleManager.UpdateAsync(existingRole);
        if (result.Succeeded)
        {
            responseModel.Success = true;
            responseModel.Message=CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}