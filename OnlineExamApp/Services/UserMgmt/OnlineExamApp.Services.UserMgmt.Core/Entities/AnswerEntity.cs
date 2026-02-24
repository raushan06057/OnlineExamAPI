namespace OnlineExamApp.Services.UserMgmt.Core.Entities;

public class AnswerEntity:BaseEntity
{
    //public QuestionEntity Question { get; set; } // The question being answered
    public int QuestionId { get; set; } // Foreign key referencing the Question model
    //public ExamAttemptEntity Attempt { get; set; } // The attempt in which this answer was given
    public int AttemptId { get; set; } // Foreign key referencing the ExamAttempt model
    public string? Text { get; set; } // The text of the answer (for essay or fill-in-the-blank questions)
    //public AnswerOptionEntity SelectedOption { get; set; } // The selected option (for multiple-choice questions)
    public int? SelectedOptionId { get; set; } // Foreign key referencing the AnswerOption model (for multiple-choice questions)
}