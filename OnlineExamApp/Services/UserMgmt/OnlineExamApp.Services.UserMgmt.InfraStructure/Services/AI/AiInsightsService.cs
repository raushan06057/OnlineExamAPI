namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Services.AI;

public class AiInsightsService : IAiInsightsService
{
    private readonly IHttpClientFactory _httpFactory;
    private readonly ILogger<AiInsightsService> _logger;
    private readonly IConfiguration _configuration;
    private readonly int _maxPromptLength = 4000;
    private readonly IChatClient chatClient;
    public AiInsightsService(IHttpClientFactory httpFactory, ILogger<AiInsightsService> logger, IConfiguration configuration, IChatClient chatClient)
    {
        _httpFactory = httpFactory ?? throw new ArgumentNullException(nameof(httpFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        this.chatClient = chatClient ?? throw new ArgumentNullException(nameof(chatClient));
    }

    public async Task<ChatResponse> GetInsightsAsync(StudentPerformanceDto features, CancellationToken cancellationToken = default)
    {
        ChatResponse response = new();
        if (features == null) throw new ArgumentNullException(nameof(features));

        var prompt = BuildPrompt(features);
        if (prompt.Length > _maxPromptLength)
        {
            prompt = prompt.Substring(0, _maxPromptLength);
        }
        try
        {
            response = await chatClient.GetResponseAsync(prompt);
            return response;
        }
        catch (Exception ex)
        {
        }
       return response;
        //// If Agentic usage is enabled, we would call Agentic SDK here. Keep a safe fallback to Ollama.
        //var useAgentic = false;
        //if (bool.TryParse(_configuration["Ai:UseAgentic"], out var parsed))
        //{
        //    useAgentic = parsed;
        //}

        //if (useAgentic)
        //{
        //    // Agentic integration is environment-dependent and may require additional packages.
        //    // For now, log and fall back to Ollama.
        //    _logger.LogInformation("AiInsightsService: Agentic requested but not configured - falling back to Ollama HTTP API.");
        //}

        //var ollamaBase = _configuration["Ollama:BaseUrl"] ?? "http://localhost:11434";
        //var ollamaModel = _configuration["Ollama:Model"] ?? "mistral";

        //var client = _httpFactory.CreateClient("ollama");
        //client.BaseAddress = new Uri(ollamaBase);

        //var requestBody = new
        //{
        //    model = ollamaModel,
        //    prompt = prompt,
        //    max_tokens = 300
        //};

        //HttpResponseMessage resp;
        //try
        //{
        //    resp = await client.PostAsJsonAsync("/api/generate", requestBody, cancellationToken);
        //}
        //catch (Exception ex)
        //{
        //    _logger.LogError(ex, "AiInsightsService: failed calling Ollama at {BaseUrl}", ollamaBase);
        //    return "AI service call failed";
        //}

        //var content = await resp.Content.ReadAsStringAsync(cancellationToken);
        //if (!resp.IsSuccessStatusCode)
        //{
        //    _logger.LogWarning("AiInsightsService: Ollama returned {Status}. Content: {Content}", resp.StatusCode, content);
        //    return $"AI service unavailable: {resp.StatusCode}";
        //}

        //// Try to extract likely fields from common responses. If parsing fails, return raw content.
        //try
        //{
        //    using var doc = JsonDocument.Parse(content);
        //    var root = doc.RootElement;

        //    if (root.ValueKind == JsonValueKind.Object)
        //    {
        //        if (root.TryGetProperty("text", out var textProp) && textProp.ValueKind == JsonValueKind.String)
        //            return textProp.GetString() ?? content;

        //        if (root.TryGetProperty("generated", out var genProp) && genProp.ValueKind == JsonValueKind.String)
        //            return genProp.GetString() ?? content;

        //        if (root.TryGetProperty("results", out var resultsProp))
        //            return resultsProp.ToString();
        //    }

        //    // fallback: return the whole JSON string trimmed
        //    return content.Length > 2000 ? content.Substring(0, 2000) : content;
        //}
        //catch (JsonException)
        //{
        //    // not JSON
        //    return content;
        //}
    }

    private string BuildPrompt(StudentPerformanceDto f)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are an assistant that summarizes student exam performance. Provide a short (3-6 sentences) insight including: trend (improving/declining), strengths, weaknesses, and a predicted pass probability.");
        sb.AppendLine();
        sb.AppendLine("Exam details:");
        sb.AppendLine($"- Id: {f.Id}");
        if (!string.IsNullOrWhiteSpace(f.Title)) sb.AppendLine($"- Title: {f.Title}");
        if (!string.IsNullOrWhiteSpace(f.Description)) sb.AppendLine($"- Description: {f.Description}");
        if (f.StartDate.HasValue) sb.AppendLine($"- StartDate: {f.StartDate:yyyy-MM-dd}");
        if (f.EndDate.HasValue) sb.AppendLine($"- EndDate: {f.EndDate:yyyy-MM-dd}");
        sb.AppendLine($"- Duration (minutes): {f.DurationInMinutes}");
        sb.AppendLine($"- Total marks: {f.TotalMarks}");
        sb.AppendLine($"- Passing marks: {f.PassingMarks}");
        sb.AppendLine();
        sb.AppendLine("Student performance:");
        sb.AppendLine($"- Attempted questions: {f.TotalAttemptedQuestions}");
        sb.AppendLine($"- Correct answers: {f.TotalCorrect}");
        sb.AppendLine($"- Wrong answers: {f.TotalWrong}");
        sb.AppendLine($"- Marks obtained: {f.MarksObtained}");
        sb.AppendLine();
        sb.AppendLine("Provide concise actionable insights. Do not output raw JSON.");

        return sb.ToString();
    }
}
