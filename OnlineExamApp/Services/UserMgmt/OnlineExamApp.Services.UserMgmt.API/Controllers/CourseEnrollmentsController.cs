namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseEnrollmentsController : ControllerBase
{
    private readonly ILogger<CourseEnrollmentsController> logger;
    private readonly IMediator mediator;

    public CourseEnrollmentsController(ILogger<CourseEnrollmentsController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpGet(CommonFields.GetById)]
    public async Task<ActionResult<ResponseModel>> GetById(int id)
    {
        var query = new GetCourseEnrollmentByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel>> Get()
    {
        var query = new GetCourseEnrollmentListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Enroll([FromBody] CreateCourseEnrollmentCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update([FromBody] UpdateCourseEnrollmentCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Unenroll([FromBody] DeleteCourseCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }
}