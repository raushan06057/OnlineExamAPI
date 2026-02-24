namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly ILogger<RolesController> logger;
    private readonly IMediator mediator;
    public RolesController(ILogger<RolesController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> AddRole([FromBody] CreateApplicationRoleCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateRole([FromBody] UpdateApplicationRoleCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> DeleteRole(string id)
    {
        DeleteApplicationRoleCommand model = new() { Id = id };
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetRole")]
    //[HttpGet(Name =CommonFields.GetById)]
    //[HttpGet(Name = "GetRoleById")]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetRoleById(string id)
    {
        var query = new GetApplicationRoleByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    //[HttpGet("{organizationId}",Name ="GetRoles")]
    [HttpGet]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetRoles(long organizationId)
    {
        var query = new GetApplicationRoleByOrganizationIdQuery(organizationId);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
