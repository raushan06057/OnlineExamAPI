namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class CourseEnrollmentAlreadyExistsException: ApplicationException
{
    public CourseEnrollmentAlreadyExistsException(string name, object key) : base($"Entity {name} already exists.")
    {

    }
}
