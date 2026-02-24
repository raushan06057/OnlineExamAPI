namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class QuestionAttemptEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long StudentInfoId { get; set; }

    public long ExamId { get; set; }

    public long QuestionId { get; set; }

    public DateTime CreatedOn { get; set; }
}
