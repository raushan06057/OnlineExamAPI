namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IConfiguration configuration;

    public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration) : base(context)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.signInManager = signInManager;
        this.configuration = configuration;
    }

    public async Task<ResponseModel> CreateAsync(ApplicationUser user, List<Claim> claims)
    {
        ResponseModel responseModel = new();
        try
        {
            var existingUser = await userManager.FindByEmailAsync(user.Email);
            if (existingUser == null)
            {
                var result = await userManager.CreateAsync(user, user.Pwd);
                if (result.Succeeded)
                {
                    var role = await roleManager.FindByIdAsync(user.Role);
                    if (role == null)
                    {
                        ApplicationRole newRole = new() { Name = user.Role, OrganizationId = user.OrganizationId };
                        await roleManager.CreateAsync(newRole);
                        await userManager.AddToRoleAsync(user, newRole.Name);
                        if (claims != null)
                        {
                            await userManager.AddClaimsAsync(user, claims.AsEnumerable());
                        }
                        await context.SaveChangesAsync();
                    }
                    responseModel.Success = true;
                    responseModel.Message = CommonResource.RecordSavedSuccessfully;
                    responseModel.Data = user;
                }
                else
                {
                    responseModel.Success = false;
                    foreach (var error in result.Errors)
                    {
                        responseModel.Message = responseModel.Message + error.Description + ", ";
                    }
                }
            }
            else
            {
                responseModel.Success = false;
                responseModel.Message = CommonResource.RecordAlreadyExists;
            }
        }
        catch (Exception ex)
        {
            throw;
        }

        return responseModel;
    }

    public async Task<ResponseModel> GetAsync(ApplicationUser user)
    {
        var users = await userManager.Users.Where(mod => mod.OrganizationId == user.OrganizationId).ToListAsync();
        var roles = await roleManager.Roles.Where(mod => mod.OrganizationId == user.OrganizationId).ToListAsync();

        var departments = await context.OrgDepartments.Where(mod => mod.OrganizationId == user.OrganizationId).ToListAsync();
        var result = (from usr in users
                      join rol in roles on usr.Role equals rol.Name
                      join dept in departments on usr.DepartmentId equals dept.Id
                      where usr.OrganizationId == user.OrganizationId
                      select new
                      {
                          Id = usr.Id,
                          RoleId = rol.Id,
                          RoleName = rol.Name,
                          UserName = usr.UserName,
                          DepartmentId = usr.DepartmentId,
                          Department = dept.Name,
                          Email = usr.Email,
                          PhoneNumber = usr.PhoneNumber
                      }).ToList();
        ResponseModel responseModel = new();
        responseModel.Success = true;
        responseModel.Data = result;
        return await Task.FromResult(responseModel);
    }

    public async Task<ResponseModel> LoginAsync(string userName, string password)
    {
        ResponseModel responseModel = new();
        var user = await userManager.FindByNameAsync(userName);
        if (user == null)
        {
            responseModel.Success = false;
            responseModel.Message = CommonResource.UserNotFound;
        }
        else
        {
            var result = await signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
            {
                responseModel.Success = false;
                responseModel.Message = CommonResource.InvalidUsernameorPassword;
            }
            if (result.Succeeded)
            {
                responseModel.Success = true;
                responseModel.Message = CommonResource.UserLoggedInSuccessfully;
                var token = GenerateJwtToken(user);
                responseModel.Data = token;
                responseModel.RoleName = user.Role;
                responseModel.OrganizationId = user.OrganizationId;
            }
        }
        return responseModel;
    }

    private string GenerateJwtToken(ApplicationUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[CommonFields.JwtColonKey] ?? "N/A"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
                new Claim(CommonFields.ID,Convert.ToString(user.Id)),
                new Claim(ClaimTypes.NameIdentifier,user.UserName??"N/A"),
                new Claim(CommonFields.UserId,Convert.ToString(user.Id)),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(CommonFields.OrganizationId,Convert.ToString(user.OrganizationId))
            };
        var token = new JwtSecurityToken(configuration[CommonFields.JwtColonIssuer],
            configuration[CommonFields.JwtColonAudience],
            claims,
            expires: DateTime.Now.AddMinutes(3600),
            signingCredentials: credentials);
        var data = new JwtSecurityTokenHandler().WriteToken(token);
        return data;
        //var jwtSettings = configuration.GetSection(CommonFields.JwtSettings);
        //var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings[CommonFields.SecretKey]));
        //var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        //var claims = new[]
        //{
        //    new Claim(ClaimTypes.NameIdentifier, user.Id),
        //    new Claim(ClaimTypes.Name, user.UserName),
        //    // Add other claims as needed
        //};
        //double expiresIn = Convert.ToDouble(jwtSettings[CommonFields.ExpiresIn]);
        //var token = new JwtSecurityToken(
        //    issuer: null,
        //    audience: null,
        //    claims: claims,
        //    expires: DateTime.UtcNow.AddSeconds(expiresIn),
        //    signingCredentials: credentials);

        //return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<ResponseModel> GetAsync(string userId)
    {
        ResponseModel responseModel = new();
        responseModel.Success = true;
        var user = await userManager.Users.Where(mod => mod.Id == userId).FirstOrDefaultAsync();
        if (user != null)
        {
            var role = await roleManager.Roles.Where(mod => mod.Id == user.Role).FirstOrDefaultAsync();
            var department = await context.OrgDepartments.Where(mod => mod.Id == user.DepartmentId).FirstOrDefaultAsync();
            var result = new
            {
                Id = user.Id,
                RoleId = role?.Id,
                RoleName = role?.Name,
                UserName = user.UserName,
                DepartmentId = user.DepartmentId,
                Department = department.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            responseModel.Data = result;
        }
        return await Task.FromResult(responseModel);
    }

    public async Task<ResponseModel> UpdateAsync(ApplicationUser user, List<Claim> claims)
    {
        ResponseModel responseModel = new();
        try
        {
            var existingUser = await userManager.FindByIdAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.Email = user.Email;
                existingUser.UserName = user.UserName;
                existingUser.PhoneNumber = user.PhoneNumber;
                var result = await userManager.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    var role = await roleManager.FindByIdAsync(user.Role);
                    if (role == null)
                    {
                        ApplicationRole newRole = new() { Name = user.Role, OrganizationId = user.OrganizationId };
                        await roleManager.CreateAsync(newRole);
                        await userManager.AddToRoleAsync(user, newRole.Name);
                        if (claims != null)
                        {
                            await userManager.AddClaimsAsync(user, claims.AsEnumerable());
                        }
                        await context.SaveChangesAsync();
                    }
                    responseModel.Success = true;
                    responseModel.Message = CommonResource.RecordSavedSuccessfully;
                    responseModel.Data = user;
                }
                else
                {
                    responseModel.Success = false;
                    foreach (var error in result.Errors)
                    {
                        responseModel.Message = responseModel.Message + error.Description + ", ";
                    }
                }
            }
            //else
            //{
            //    responseModel.Success = false;
            //    responseModel.Message = CommonResource.RecordAlreadyExists;
            //}
        }
        catch (Exception ex)
        {
            throw;
        }

        return responseModel;
    }

}