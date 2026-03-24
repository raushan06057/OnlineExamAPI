namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly ILogger<StudentsController> logger;
    private readonly IMediator mediator;

    public StudentsController(ILogger<StudentsController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }
    
    [HttpGet(CommonFields.GetById)]
    public async Task<ActionResult<ResponseModel>> GetById(int id)
    {
        var query = new GetStudentByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }
    [HttpGet(CommonFields.GetUpComingExams)]
    public async Task<ActionResult<ResponseModel>> GetUpComingExams()
    {
        string userId = Convert.ToString(HttpContext.Items[CommonFields.UserId]);
        var query = new GetUpcomingExamsListQuery(userId);
        var result = await mediator.Send(query);
        return Ok(result);
    }
    [HttpGet]
    public async Task<ActionResult<ResponseModel>> Get()
    {
        var query = new GetStudentListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Add([FromBody] CreateStudentInfoCommand model)
    {
        model.CreatedBy = Convert.ToString(HttpContext.Items[CommonFields.UserId]);
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update([FromBody] UpdateStudentInfoCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete([FromBody] DeleteStudentInfoCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpGet(CommonFields.GetStudentExamResults)]
    public async Task<ActionResult<ResponseModel>> GetStudentExamResultsGetById()
    {
        string userId = Convert.ToString(HttpContext.Items[CommonFields.UserId]);
        var query = new GetStudentExamResultsListQuery(userId);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}