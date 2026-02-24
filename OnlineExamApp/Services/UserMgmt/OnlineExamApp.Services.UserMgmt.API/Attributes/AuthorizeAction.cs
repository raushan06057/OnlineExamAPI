namespace OnlineExamApp.Services.UserMgmt.API.Attributes;

public class AuthorizeAction : IAuthorizationFilter
{
    private readonly string controller;
    private readonly string actionName;
    private readonly string roleType;
    public AuthorizeAction(string controller, string actionName, string roleType)
    {
        this.controller = controller;
        this.actionName = actionName;
        this.roleType = roleType;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string? userId = Convert.ToString(context.HttpContext.Items[CommonFields.UserId]);
        if (string.IsNullOrEmpty(userId))
        {
            context.Result = new JsonResult(CommonResource.PermissionDenined);
        }
        //switch (actionName)
        //{
        //    case "Index":
        //        if (!_roleType.Contains("admin")) context.Result = new JsonResult("Permission denined!");
        //        break;
        //}
    }
}
