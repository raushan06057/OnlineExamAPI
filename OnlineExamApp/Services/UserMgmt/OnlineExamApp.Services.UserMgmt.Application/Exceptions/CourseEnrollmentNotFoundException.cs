namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class CourseEnrollmentNotFoundException:ApplicationException
{
    public CourseEnrollmentNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
    {
            
    }
}
