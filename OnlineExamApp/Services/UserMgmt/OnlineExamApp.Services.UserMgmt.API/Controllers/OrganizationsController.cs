namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizationsController : ControllerBase
{
    private readonly ILogger<OrganizationsController> logger;
    private readonly IMediator mediator;
    public OrganizationsController(ILogger<OrganizationsController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpGet]
    [AuthAttribute(CommonFields.Organizations, CommonFields.Get, CommonFields.Admin)]
    public async Task<ActionResult<IEnumerable<OrganizationResponse>>> GetOrg()
    { 
        var query = new GetOrganizationListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(CommonFields.GetById)]
    [AuthAttribute(CommonFields.Organizations, CommonFields.Get, CommonFields.Admin)]
    public async Task<ActionResult<IEnumerable<OrganizationResponse>>> GetOrg(long id)
    {
        var query = new GetOrgByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel),(int) HttpStatusCode.OK)]
    //[AuthAttribute(CommonFields.Organizations, CommonFields.Post, CommonFields.Admin)]
    public async Task<ActionResult> AddOrg([FromBody]CreateOrganizationCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseModel),(int) HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [AuthAttribute(CommonFields.Organizations, CommonFields.Put, CommonFields.Admin)]
    public async Task<ActionResult> UpdateOrg([FromBody] UpdateOrganizationCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    [AuthAttribute(CommonFields.Organizations, CommonFields.Delete, CommonFields.Admin)]
    public async Task<ActionResult> DeleteOrg([FromBody] DeleteOrganizationCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }
}