namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class DeleteStudentInfoCommandHandler : IRequestHandler<DeleteStudentInfoCommand, ResponseModel>
{
    private readonly IStudentInfoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<DeleteStudentInfoCommandHandler> logger;

    public DeleteStudentInfoCommandHandler(
        IStudentInfoRepository repository,
        IMapper mapper,
        ILogger<DeleteStudentInfoCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(DeleteStudentInfoCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Retrieve the student to delete
        var studentToDelete = await repository.GetAsync(request.Id);

        if (studentToDelete == null)
        {
            throw new StudentNotFoundException(nameof(request), request.Id);
        }

        // Delete the student
        await repository.DeleteAsync(studentToDelete);

        responseModel.Success = true;
        logger.LogInformation($"Student info with Id {request.Id} deleted successfully.");
        responseModel.Message = CommonResource.RecordDeletedSuccessfully;

        return responseModel;
    }
}