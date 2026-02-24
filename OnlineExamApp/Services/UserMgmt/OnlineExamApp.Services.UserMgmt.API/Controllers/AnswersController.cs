namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswersController : ControllerBase
{
    private readonly ILogger<AnswersController> logger;
    private readonly IMediator mediator;

    public AnswersController(ILogger<AnswersController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpGet(CommonFields.GetById)]
    public async Task<ActionResult<ResponseModel>> GetById(int id)
    {
        var query = new GetAnswerByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel>> Get()
    {
        var query = new GetAnswerListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Add([FromBody] CreateAnswerCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update([FromBody] UpdateAnswerOptionCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete([FromBody] DeleteAnswerOptionCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }
}