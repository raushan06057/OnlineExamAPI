namespace OnlineExamApp.Services.UserMgmt.API.Attributes;

public class AuthAttribute : TypeFilterAttribute
{
    public AuthAttribute(string controller, string actionName, string roleType) : base(typeof(AuthorizeAction))
    {
        Arguments = new object[] {
            controller,
            actionName,
            roleType
        };
    }
}
