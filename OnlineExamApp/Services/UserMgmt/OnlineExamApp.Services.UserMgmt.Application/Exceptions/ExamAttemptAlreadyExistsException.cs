namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class ExamAttemptAlreadyExistsException : ApplicationException
{
    public ExamAttemptAlreadyExistsException(string name, object key) : base($"Entity {name} already exists.")
    {
        // Optionally, you can add additional data or properties here if needed.
    }
}