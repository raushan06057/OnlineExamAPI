namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class CourseNotFoundException:ApplicationException
{
    public CourseNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
    {
        
    }
}
