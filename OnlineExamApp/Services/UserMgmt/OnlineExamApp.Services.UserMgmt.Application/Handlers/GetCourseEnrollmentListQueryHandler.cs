using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace OnlineExamApp.Services.UserMgmt.Application.Handlers;

public class GetCourseEnrollmentListQueryHandler : IRequestHandler<GetCourseEnrollmentListQuery, ResponseModel>
{
    private readonly ICourseEnrollmentRepository repository;
    private readonly ICourseRepository courseRepository;
    private readonly IStudentInfoRepository studentInfoRepository;

    public GetCourseEnrollmentListQueryHandler(ICourseEnrollmentRepository repository, ICourseRepository courseRepository, IStudentInfoRepository studentInfoRepository)
    {
        this.repository = repository;
        this.courseRepository = courseRepository;
        this.studentInfoRepository = studentInfoRepository;
    }

    public async Task<ResponseModel> Handle(GetCourseEnrollmentListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var enrollments = repository.GetQueryAsync();
        var courses = courseRepository.GetQueryAsync();
        var students = studentInfoRepository.GetQueryAsync();
        var result = await (from enrollment in enrollments
                      join student in students on enrollment.StudentId equals student.Id
                      join course in courses on enrollment.CourseId equals course.Id
                      select new
                      {
                          enrollment.Id,
                          enrollment.StudentId,
                          enrollment.CourseId,
                          enrollment.EnrollmentDate,
                          enrollment.CompletionDate,
                          enrollment.Grade,
                          StudentName = student.FirstName+" "+student.LastName,
                          CourseName = course.Title,
                          course.OrganizationId

                      }).ToListAsync();

        responseModel.Success = true;
        responseModel.Data = result;
        return responseModel;
    }
}