
using Microsoft.EntityFrameworkCore;

namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetQuestionListByExamIdQueryHandler : IRequestHandler<GetQuestionListByExamIdQuery, ResponseModel>
{
    private readonly IQuestionRepository repository;
    private readonly IAnswerOptionRepository answerOptionRepository;
    public GetQuestionListByExamIdQueryHandler(IQuestionRepository repository,
        IAnswerOptionRepository answerOptionRepository)
    {
        this.repository = repository;
        this.answerOptionRepository = answerOptionRepository;
    }

    public async Task<ResponseModel> Handle(GetQuestionListByExamIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var questionsQuery = repository.GetQueryAsync();
        var answerOptionsQuery = answerOptionRepository.GetQueryAsync();
        var questionsWithOptions = (from quest in questionsQuery where quest.ExamId==request.ExamId
                      join ansOpt in answerOptionsQuery
                      on quest.Id equals ansOpt.QuestionId into optionsGroup
                      select new QuestionEntity
                      {
                          Id=quest.Id,
                          Text=quest.Text,
                          Type=quest.Type,
                          ExamId=quest.ExamId,
                          Marks = quest.Marks,
                          AnswerOptions = optionsGroup.ToList()
                      });
        //var answerOptions = questions.Include(mod => mod.AnswerOptions);//.AsNoTracking();
        //var questionList = await questions.Where(mod=>mod.ExamId==request.ExamId).ToListAsync();
        var questions = await questionsWithOptions.ToListAsync();
        if (questions == null)
        {
            throw new QuestionNotFoundException(nameof(request), request.ExamId);
        }

        responseModel.Success = true;
        responseModel.Data = questions;
        return responseModel;
    }
}
