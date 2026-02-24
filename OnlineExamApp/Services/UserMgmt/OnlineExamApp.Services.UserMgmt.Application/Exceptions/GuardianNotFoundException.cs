namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class GuardianNotFoundException : ApplicationException
{
    public GuardianNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
    {

    }
}
