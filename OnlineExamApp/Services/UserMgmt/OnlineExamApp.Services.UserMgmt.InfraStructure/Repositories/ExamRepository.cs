namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Repositories;

public class ExamRepository : RepositoryBase<ExamEntity>, IExamRepository
{
    public ExamRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsExamExistsAsync(string name, long organizationId)
    {
        var isExamExist = await context.Exams.AnyAsync(mod => mod.Title == name && mod.OrganizationId == organizationId);
        return isExamExist;
    }
    public async Task<dynamic> GetExamsAsync(string username)
    {
        var result = await context.Exams.Include(mod => mod.Organization).Include(crs => crs.Course)
            .Include(sub => sub.Subject).Select(mod => new
            {
                mod.Id,
                mod.Title,
                mod.Description,
                mod.StartDate,
                mod.EndDate,
                mod.DurationInMinutes,
                OrgName = mod.Organization.Name,
                OrganizationId = mod.Organization.Id,
                mod.DepartmentId,
                mod.SubjectId,
                CourseName = mod.Course.Title,
                SubjectName = mod.Subject.Name,
                mod.CourseId,
                mod.TotalMarks,
                mod.PassingMarks,
                mod.IsScheduled
            }).ToListAsync();
        return result;
    }

    public async Task<dynamic> GetStudentExamSchedules(string studentId)
    {
        var result = await (from exam in context.Exams
                            join course in context.Courses
                              on exam.CourseId equals course.Id
                            join corsEnroll in context.CourseEnrollments
                               on course.Id equals corsEnroll.CourseId

                            join stud in context.StudentInfos
                                on corsEnroll.StudentId equals stud.Id
                            where stud.UserId == studentId
                                  // exclude exams that already have question attempts or attempt answers for this student
                                  && !context.QuestionAttempts.Any(qa => qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id)
                                  && !context.AttemptAnswers.Any(aa => context.QuestionAttempts
                                                                      .Any(qa => qa.Id == aa.QuestionAttemptId && qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id))
                            select new
                            {
                                exam.Id,
                                exam.Title,
                                exam.Description,
                                exam.StartDate,
                                exam.EndDate,
                                exam.DurationInMinutes,

                            }).ToListAsync();
        //var result = string.Empty;
        return result;
    }

    public async Task<dynamic> GetStudentExamResultsAsync(string userId)
    {
        //Total Marks, Marks Obtained, Total attempted questions, Total correct answer, Total wrong answer, Passed or Failed
        var result = await (from exam in context.Exams
                            join course in context.Courses
                              on exam.CourseId equals course.Id
                            join corsEnroll in context.CourseEnrollments
                               on course.Id equals corsEnroll.CourseId
                            join stud in context.StudentInfos
                                on corsEnroll.StudentId equals stud.Id
                            where stud.UserId == userId && context.QuestionAttempts.Any(qa => qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id) && context.AttemptAnswers.Any(aa => context.QuestionAttempts.Any(qa => qa.Id == aa.QuestionAttemptId && qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id))

                            select new
                            {
                                exam.Id,
                                exam.Title,
                                exam.Description,
                                exam.StartDate,
                                exam.EndDate,
                                exam.DurationInMinutes,
                                exam.TotalMarks,
                                exam.PassingMarks,
                                TotalAttemptedQuestions = context.AttemptAnswers
                                    .Where(aa => aa.IsSelected == true)
                                    .Join(context.QuestionAttempts.Where(qa => qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id),
                                          aa => aa.QuestionAttemptId,
                                          qa => qa.Id,
                                          (aa, qa) => qa.QuestionId)
                                    .Distinct()
                                    .Count(),
                                // distinct questions where selected option was correct
                                TotalCorrect = context.AttemptAnswers
                                    .Where(aa => aa.IsSelected == true && aa.IsCorrect == true)
                                    .Join(context.QuestionAttempts.Where(qa => qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id),
                                          aa => aa.QuestionAttemptId,
                                          qa => qa.Id,
                                          (aa, qa) => qa.QuestionId)
                                    .Distinct()
                                    .Count(),

                                // marks obtained: sum of question.Marks for questions that the student answered correctly
                                MarksObtained = (context.QuestionAttempts
                                    .Where(qa => qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id)
                                    .Where(qa => context.AttemptAnswers.Any(aa => aa.QuestionAttemptId == qa.Id && aa.IsSelected == true && aa.IsCorrect == true))
                                    .Join(context.Questions,
                                          qa => qa.QuestionId,
                                          q => q.Id,
                                          (qa, q) => (int?)q.Marks)
                                    .Sum() ?? 0),
                                // wrong = attempted - correct
                                TotalWrong = context.AttemptAnswers
                                    .Where(aa => aa.IsSelected == true)
                                    .Join(context.QuestionAttempts.Where(qa => qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id),
                                          aa => aa.QuestionAttemptId,
                                          qa => qa.Id,
                                          (aa, qa) => qa.QuestionId)
                                    .Distinct()
                                    .Count()

                            }).ToListAsync();
        return result;
    }

    public async Task<StudentPerformanceDto> GetStudentExamResultsByIdAsync(string userId, long examId)
    {
        //Total Marks, Marks Obtained, Total attempted questions, Total correct answer, Total wrong answer, Passed or Failed
        var result = await (from exam in context.Exams
                            join course in context.Courses
                              on exam.CourseId equals course.Id
                            join corsEnroll in context.CourseEnrollments
                               on course.Id equals corsEnroll.CourseId

                            join stud in context.StudentInfos
                                on corsEnroll.StudentId equals stud.Id
                            where stud.UserId == userId && exam.Id == examId
                            select new StudentPerformanceDto()
                            {
                                Id = exam.Id,
                                Title = exam.Title,
                                Description = exam.Description,
                                StartDate = exam.StartDate,
                                EndDate = exam.EndDate,
                                DurationInMinutes = exam.DurationInMinutes,
                                TotalMarks = exam.TotalMarks,
                                PassingMarks = exam.PassingMarks,
                                TotalAttemptedQuestions = context.AttemptAnswers
                                    .Where(aa => aa.IsSelected == true)
                                    .Join(context.QuestionAttempts.Where(qa => qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id),
                                          aa => aa.QuestionAttemptId,
                                          qa => qa.Id,
                                          (aa, qa) => qa.QuestionId)
                                    .Distinct()
                                    .Count(),
                                // distinct questions where selected option was correct
                                TotalCorrect = context.AttemptAnswers
                                    .Where(aa => aa.IsSelected == true && aa.IsCorrect == true)
                                    .Join(context.QuestionAttempts.Where(qa => qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id),
                                          aa => aa.QuestionAttemptId,
                                          qa => qa.Id,
                                          (aa, qa) => qa.QuestionId)
                                    .Distinct()
                                    .Count(),

                                // marks obtained: sum of question.Marks for questions that the student answered correctly
                                MarksObtained = (context.QuestionAttempts
                                    .Where(qa => qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id)
                                    .Where(qa => context.AttemptAnswers.Any(aa => aa.QuestionAttemptId == qa.Id && aa.IsSelected == true && aa.IsCorrect == true))
                                    .Join(context.Questions,
                                          qa => qa.QuestionId,
                                          q => q.Id,
                                          (qa, q) => (int?)q.Marks)
                                    .Sum() ?? 0),
                                // wrong = attempted - correct
                                TotalWrong = context.AttemptAnswers
                                    .Where(aa => aa.IsSelected == true)
                                    .Join(context.QuestionAttempts.Where(qa => qa.ExamId == exam.Id && qa.StudentInfoId == stud.Id),
                                          aa => aa.QuestionAttemptId,
                                          qa => qa.Id,
                                          (aa, qa) => qa.QuestionId)
                                    .Distinct()
                                    .Count()

                            }).FirstOrDefaultAsync();
        return result;
    }
}