namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class AttemptAnswerEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long QuestionAttemptId { get; set; }

    public long AnswerOptionsId { get; set; }

    public bool IsSelected { get; set; }

    public bool IsCorrect { get; set; }
}
