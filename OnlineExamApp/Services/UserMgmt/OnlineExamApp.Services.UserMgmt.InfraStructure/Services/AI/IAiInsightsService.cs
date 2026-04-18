namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Services.AI;

public interface IAiInsightsService
{
    /// <summary>
    /// Generate short student performance insights for the provided features.
    /// Returns a human-readable summary (trend, strengths, weaknesses, pass-probability).
    /// </summary>
    Task<ChatResponse> GetInsightsAsync(StudentPerformanceDto features, CancellationToken cancellationToken = default);
    Task<ChatResponse> GetChartAsync(StudentPerformanceDto features, CancellationToken cancellationToken = default);
}
