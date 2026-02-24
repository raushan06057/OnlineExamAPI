namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class GuardianAlreadyExistsException : ApplicationException
{
    public GuardianAlreadyExistsException(string name, object key) : base($"Entity {name} - {key} already exists.")
    {

    }
}
