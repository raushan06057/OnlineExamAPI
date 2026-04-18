namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentQuestionAttemptsController : ControllerBase
{
    private readonly ILogger<StudentQuestionAttemptsController> logger;
    private readonly IMediator mediator;
    public StudentQuestionAttemptsController(ILogger<StudentQuestionAttemptsController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Add([FromBody] CreateStudentQuestionAttemptCommand model)
    {
        model.CreatedBy = HttpContext.Items[CommonFields.UserId] as string;
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpGet("{id}", Name = CommonFields.Submit)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Submit(long id)
    {
        var model = new CreateStudentExamSubmitCommand();
        model.CreatedBy = HttpContext.Items[CommonFields.UserId] as string;
        model.ExamId = id;
        var result = await mediator.Send(model);
        return Ok(result);
    }
    [HttpGet("{id}/graph")]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Graph(long id)
    {
        var model = new CreateStudentExamGraphCommand();
        model.CreatedBy = HttpContext.Items[CommonFields.UserId] as string;
        model.ExamId = id;
        var result = await mediator.Send(model);
        return Ok(result);
    }
}
