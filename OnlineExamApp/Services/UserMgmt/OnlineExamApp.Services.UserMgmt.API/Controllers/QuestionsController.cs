namespace OnlineExamApp.Services.UserMgmt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly ILogger<QuestionsController> logger;
    private readonly IMediator mediator;

    public QuestionsController(ILogger<QuestionsController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpGet(CommonFields.GetById)]
    public async Task<ActionResult<ResponseModel>> GetById(int id)
    {
        var query = new GetQuestionByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(CommonFields.GetByExamId)]
    public async Task<ActionResult<ResponseModel>> GetByExamId(long id)
    {
        var query = new GetQuestionListByExamIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel>> Get()
    {
        var query = new GetQuestionListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Add([FromBody] CreateQuestionCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    //[ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update([FromBody] UpdateQuestionCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete([FromBody] DeleteQuestionCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }
}