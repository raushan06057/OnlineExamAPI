namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class SubjectAlreadyExistsException: ApplicationException
{
    public SubjectAlreadyExistsException(string name, object key) : base($"Entity {name} already exists.")
    {
    }
}