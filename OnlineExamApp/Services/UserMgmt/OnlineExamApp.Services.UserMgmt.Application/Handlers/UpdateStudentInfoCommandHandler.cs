namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class UpdateStudentInfoCommandHandler : IRequestHandler<UpdateStudentInfoCommand, ResponseModel>
{
    private readonly IStudentInfoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateStudentInfoCommandHandler> logger;

    public UpdateStudentInfoCommandHandler(
        IStudentInfoRepository repository,
        IMapper mapper,
        ILogger<UpdateStudentInfoCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(UpdateStudentInfoCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();

        // Map the command to the entity
        var studentEntity = mapper.Map<StudentInfoEntity>(request);

        // Retrieve the student to update
        var studentToUpdate = await repository.GetAsync(request.Id);

        if (studentToUpdate == null)
        {
            throw new StudentNotFoundException(nameof(request), request.Id);
        }

        // Update the student information
        var updatedStudent = await repository.UpdateAsync(studentEntity);

        if (updatedStudent.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = updatedStudent;
            logger.LogInformation($"Student info {updatedStudent} updated successfully.");
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }

        return responseModel;
    }
}