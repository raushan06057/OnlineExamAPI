namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class StudentNotFoundException : ApplicationException
{
    public StudentNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
    {

    }
}
