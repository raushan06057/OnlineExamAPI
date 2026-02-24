namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ILogger<CoursesController> logger;
    private readonly IMediator mediator;

    public CoursesController(ILogger<CoursesController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpGet(CommonFields.GetById)]
    public async Task<ActionResult<ResponseModel>> GetById(int id)
    {
        var query = new GetCourseByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel>> Get()
    {
        var query = new GetCourseListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Add([FromBody] CreateCourseCommand model)
    {
        model.CreatedBy = HttpContext.Items[CommonFields.UserId] as string;
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update([FromBody] UpdateCourseCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete([FromBody] DeleteCourseCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }
}