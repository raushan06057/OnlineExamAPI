namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class QuestionAttemptAlreadyExistsException: ApplicationException
{
    public QuestionAttemptAlreadyExistsException(string name, object key) : base($"Entity {name} already exists.")
    {
        // Optionally, you can add additional data or properties here if needed.
    }
}
