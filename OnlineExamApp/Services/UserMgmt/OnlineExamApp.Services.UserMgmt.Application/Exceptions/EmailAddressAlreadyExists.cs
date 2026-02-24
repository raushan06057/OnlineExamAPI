namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class EmailAddressAlreadyExistsException: ApplicationException
{
    public EmailAddressAlreadyExistsException(string name, object key):base($"Entity {name} already exists.")
    {
        
    }
}
