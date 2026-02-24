namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> logger;
    private readonly IMediator mediator;
    public UsersController(ILogger<UsersController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }
  
    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> AddUser([FromBody] CreateApplicationUserCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPost(CommonFields.Login)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Login([FromBody] LoginCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Update([FromBody] UpdateApplicationUserCommand model)
    { 
        var result = await mediator.Send(model);
        return Ok(result);
    }
    [HttpGet]
    public async Task<ActionResult> Get(long orgId)
    {
        GetOrgUserListByOrgIdQuery model = new(orgId);
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpGet("userdetails")]
    public async Task<ActionResult> Get(string userId)
    {
        GetOrgUserDetailsByIdQuery model = new(userId);
        var result = await mediator.Send(model);
        return Ok(result);
    }
}