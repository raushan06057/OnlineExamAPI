namespace OnlineExamApp.Services.UserMgmt.Core.Models;

public class StudentPerformanceDto
{
    public StudentPerformanceDto()
    {
        QuestionPerformanceDtos = new();
    }
    public long Id { get; set; }
    public string? UserId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? DurationInMinutes { get; set; }
    public int? TotalMarks { get; set; }
    public int? PassingMarks { get; set; }
    public int? TotalAttemptedQuestions { get; set; }
    public int? TotalCorrect { get; set; }
    public int? MarksObtained { get; set; }
    public int? TotalWrong { get; set; }
    public List<QuestionPerformanceDto> QuestionPerformanceDtos { get; set; }
}

public class QuestionPerformanceDto
{
    public long QuestionId { get; set; }
    public string? QuestionText { get; set; }
    public bool IsCorrect { get; set; }
    public int MarksObtained { get; set; }
    public int MaxMarks { get; set; }
}