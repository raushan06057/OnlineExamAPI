namespace OnlineExamApp.Services.UserMgmt.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException() : base("One or more validation error(s) occurred.")
    {
        Errors= new Dictionary<string, string[]>();
    }

}
