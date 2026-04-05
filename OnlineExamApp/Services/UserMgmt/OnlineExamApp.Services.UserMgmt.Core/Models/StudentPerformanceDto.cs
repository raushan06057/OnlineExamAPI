namespace OnlineExamApp.Services.UserMgmt.Core.Models;

public class StudentPerformanceDto
{
    public long Id { get; set; }
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

    // Additional fields can be added later (course id, student id, timestamps etc.)
}
