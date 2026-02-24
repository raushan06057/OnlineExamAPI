namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class ExamAttemptNotFoundException : ApplicationException
{
    public ExamAttemptNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
    {
        // Optionally, you can add additional data or properties here if needed.
    }
}