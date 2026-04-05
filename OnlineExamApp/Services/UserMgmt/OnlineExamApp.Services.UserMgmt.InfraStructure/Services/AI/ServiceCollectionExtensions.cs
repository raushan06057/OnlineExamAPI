namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Services.AI;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAiInsights(this IServiceCollection services, IConfiguration configuration)
    {
        // Http client used to call Ollama local API (fallback). Base address is set in AiInsightsService.
        services.AddHttpClient("ollama");

        services.AddSingleton<IAiInsightsService, AiInsightsService>();

        return services;
    }
}