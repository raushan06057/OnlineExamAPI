namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class OrganizationDeptNotFoundException : ApplicationException
{
    public OrganizationDeptNotFoundException(string name, object key):base($"Entity {name} - {key} is not found")
    {
        
    }
}