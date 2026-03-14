namespace OnlineExamApp.Services.UserMgmt.Core.Common;

public class ResponseModel
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
    public string? RoleName { get; set; }
    public long? OrganizationId { get; set; }
    public string? Username { get; set; }
}