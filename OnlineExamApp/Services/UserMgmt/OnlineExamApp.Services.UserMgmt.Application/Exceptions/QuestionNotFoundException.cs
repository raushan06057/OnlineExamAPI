namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class QuestionNotFoundException : ApplicationException
{
    public QuestionNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
    {

    }
}