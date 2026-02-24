namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class OrganizationNotFoundException : ApplicationException
{
    public OrganizationNotFoundException(string name,object key):base($"Entity {name} - {key} is not found.")
    {
        
    }
}