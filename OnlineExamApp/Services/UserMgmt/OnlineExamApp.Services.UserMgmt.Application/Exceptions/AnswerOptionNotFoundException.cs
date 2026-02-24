namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class AnswerOptionNotFoundException : ApplicationException
{
    public AnswerOptionNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
    {
        // Optionally, you can add additional data or properties here if needed.
    }
}