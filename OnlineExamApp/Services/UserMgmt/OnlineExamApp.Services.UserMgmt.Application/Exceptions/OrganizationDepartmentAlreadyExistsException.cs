namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class OrganizationDepartmentAlreadyExistsException:ApplicationException
{
    public OrganizationDepartmentAlreadyExistsException(string name,object key):base($"Entity {name} already exists.")
    {
        
    }
}