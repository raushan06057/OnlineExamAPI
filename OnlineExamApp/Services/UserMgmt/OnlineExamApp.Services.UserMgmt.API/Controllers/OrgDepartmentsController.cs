namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrgDepartmentsController : ControllerBase
{
    private readonly ILogger<OrgDepartmentsController> logger;
    private readonly IMediator mediator;
    public OrgDepartmentsController(ILogger<OrgDepartmentsController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel>> Get()
    {
        var query = new GetOrgDepartmentListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(CommonFields.GetByOrgId)]
    public async Task<ActionResult<ResponseModel>> GetByOrgId(long orgId)
    {
        var query = new GetOrgDepartmentByOrganizationIdQuery(orgId);
        var result = await mediator.Send(query)  ;
        return Ok(result);
    }

    [HttpGet(CommonFields.GetById)]
    public async Task<ActionResult<ResponseModel>> GetById(long id)
    {
        var query = new GetOrgDepartmentByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    //[AuthAttribute(CommonFields.Organizations, CommonFields.Post, CommonFields.Admin)]
    public async Task<ActionResult> Add([FromBody] CreateOrgDepartmentCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [AuthAttribute(CommonFields.Organizations, CommonFields.Post, CommonFields.Admin)]
    public async Task<ActionResult> Update([FromBody] UpdateOrgDepartmentCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete([FromBody] DeleteOrgDepartmentCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }
}