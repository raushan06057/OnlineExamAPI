namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswerOptionsController : ControllerBase
{
    private readonly ILogger<AnswerOptionsController> logger;
    private readonly IMediator mediator;

    public AnswerOptionsController(ILogger<AnswerOptionsController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpGet(CommonFields.GetById)]
    public async Task<ActionResult<ResponseModel>> GetById(int id)
    {
        var query = new GetAnswerOptionByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(CommonFields.GetByExamId)]
    public async Task<ActionResult<ResponseModel>> Get(long examId)
    {
        var query = new GetAnswerOptionListQuery(examId);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Add([FromBody] CreateAnswerOptionCommand model)
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