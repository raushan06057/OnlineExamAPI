namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class OrganizationAlreadyExistsException : ApplicationException
{
    public OrganizationAlreadyExistsException(string name, object key):base($"Entity {name} already exists.")
    {
        
    }
}