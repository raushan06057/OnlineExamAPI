namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class CourseAlreadyExistsException:ApplicationException
{
    public CourseAlreadyExistsException(string name, object key) : base($"Entity {name} already exists.")
    {
    }
}
