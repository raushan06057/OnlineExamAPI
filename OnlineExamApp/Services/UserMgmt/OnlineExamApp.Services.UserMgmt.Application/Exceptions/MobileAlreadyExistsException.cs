namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class MobileAlreadyExistsException : ApplicationException
{
    public MobileAlreadyExistsException(string name, object key) : base($"Entity {name} already exists.")
    {

    }
}
