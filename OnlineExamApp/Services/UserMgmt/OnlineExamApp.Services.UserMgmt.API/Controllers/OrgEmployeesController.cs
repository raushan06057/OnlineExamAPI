namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrgEmployeesController : ControllerBase
{
    private readonly ILogger<OrgEmployeesController> logger;
    private readonly IMediator mediator;
    public OrgEmployeesController(ILogger<OrgEmployeesController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpGet(CommonFields.GetById)]
    public async Task<ActionResult<ResponseModel>> GetById(long id)
    {
        var query = new GetOrgEmployeeByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(CommonFields.GetByRoleId)]
    public async Task<ActionResult<ResponseModel>> GetByRoleId(string roleId)
    {
        var query = new GetOrgEmployeeByRoleIdQuery(roleId);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(CommonFields.GetByOrgId)]
    public async Task<ActionResult<ResponseModel>> GetByOrgId(long orgId)
    {
        var query = new GetOrgEmployeeListByOrgIdQuery(orgId);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(CommonFields.GetByDeptId)]
    public async Task<ActionResult<ResponseModel>> GetByDeptId(long orgId)
    {
        var query = new GetOrgEmployeeListByOrgIdQuery(orgId);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel>> Get()
    {
        var query = new GetOrgEmployeeListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Add([FromBody] CreateOrgEmployeeCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update([FromBody] UpdateOrgEmployeeCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete([FromBody] DeleteOrgEmployeeCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }
}