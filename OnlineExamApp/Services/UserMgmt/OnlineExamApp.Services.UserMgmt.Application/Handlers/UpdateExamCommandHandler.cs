namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, ResponseModel>
{
    private readonly IExamRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateExamCommandHandler> logger;

    public UpdateExamCommandHandler(IExamRepository repository, IMapper mapper, ILogger<UpdateExamCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Map the update request to an ExamEntity
        var exam = mapper.Map<ExamEntity>(request);

        // Check if the exam exists
        var examToUpdate = await repository.GetAsync(request.Id);
        if (examToUpdate == null)
        {
            throw new ExamNotFoundException(nameof(request.Id), request.Id);
        }

        // Update the exam in the repository
        var updatedExam = await repository.UpdateAsync(exam);

        if (updatedExam.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = updatedExam;
            logger.LogInformation($"Exam with ID {request.Id} updated successfully.");
            responseModel.Message = CommonResource.RecordUpdatedSuccessfully;
        }

        return responseModel;
    }
}