namespace OnlineExamApp.Services.UserMgmt.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateApplicationUserCommand, ApplicationUser>().ReverseMap();
        CreateMap<UpdateApplicationUserCommand, ApplicationUser>().ReverseMap();
        CreateMap<CreateOrganizationCommand, OrganizationEntity>().ReverseMap();
        CreateMap<UpdateOrganizationCommand, OrganizationEntity>().ReverseMap();
        CreateMap<OrganizationResponse, OrganizationEntity>().ReverseMap();
        CreateMap<GetUserListQuery, ApplicationUser>().ReverseMap();
        CreateMap<CreateApplicationRoleCommand, ApplicationRole>().ReverseMap();
        CreateMap<UpdateApplicationRoleCommand, ApplicationRole>().ReverseMap();
        CreateMap<DeleteApplicationRoleCommand, ApplicationRole>().ReverseMap();
        CreateMap<CreateOrgDepartmentCommand, OrgDepartmentEntity>().ReverseMap();
        CreateMap<UpdateOrgDepartmentCommand, OrgDepartmentEntity>().ReverseMap();
        CreateMap<DeleteOrgDepartmentCommand, OrgDepartmentEntity>().ReverseMap();
        CreateMap<CreateOrgEmployeeCommand, OrgEmployeeEntity>().ReverseMap();
        CreateMap<UpdateOrgEmployeeCommand, OrgEmployeeEntity>().ReverseMap();
        CreateMap<DeleteOrgEmployeeCommand, OrgEmployeeEntity>().ReverseMap();
        CreateMap<CreateCourseEnrollmentCommand, CourseEnrollmentEntity>().ReverseMap();
        CreateMap<UpdateCourseEnrollmentCommand, CourseEnrollmentEntity>().ReverseMap();
        CreateMap<DeleteCourseEnrollmentCommand, CourseEnrollmentEntity>().ReverseMap();
        CreateMap<CreateCourseCommand, CourseEntity>().ReverseMap();
        CreateMap<UpdateCourseCommand, CourseEntity>().ReverseMap();
        CreateMap<DeleteCourseCommand, CourseEntity>().ReverseMap();
        CreateMap<CreateStudentInfoCommand, StudentInfoEntity>().ReverseMap();
        CreateMap<UpdateStudentInfoCommand, StudentInfoEntity>().ReverseMap();
        CreateMap<DeleteStudentInfoCommand, StudentInfoEntity>().ReverseMap();
        CreateMap<CreateGuardianInfoCommand, GuardianInfoEntity>().ReverseMap();
        CreateMap<UpdateGuardianInfoCommand, GuardianInfoEntity>().ReverseMap();
        CreateMap<DeleteGuardianInfoCommand, GuardianInfoEntity>().ReverseMap();
        CreateMap<CreateExamCommand, ExamEntity>().ReverseMap();
        CreateMap<UpdateExamCommand, ExamEntity>().ReverseMap();
        CreateMap<DeleteExamCommand, ExamEntity>().ReverseMap();
        CreateMap<CreateSubjectCommand, SubjectEntity>().ReverseMap();
        CreateMap<UpdateSubjectCommand, SubjectEntity>().ReverseMap();
        CreateMap<CreateQuestionCommand, QuestionEntity>().ReverseMap();
        CreateMap<UpdateQuestionCommand, QuestionEntity>().ReverseMap();
        CreateMap<DeleteQuestionCommand, QuestionEntity>().ReverseMap();
        CreateMap<CreateAnswerOptionCommand, AnswerOptionEntity>().ReverseMap();
        CreateMap<AnswerOptionModel, AnswerOptionEntity>().ReverseMap();
        CreateMap<UpdateAnswerOptionCommand, AnswerOptionEntity>().ReverseMap();
        CreateMap<DeleteAnswerOptionCommand, AnswerOptionEntity>().ReverseMap();
        CreateMap<CreateExamAttemptCommand, ExamAttemptEntity>().ReverseMap();
        CreateMap<UpdateExamAttemptCommand, ExamAttemptEntity>().ReverseMap();
        CreateMap<DeleteExamAttemptCommand, ExamAttemptEntity>().ReverseMap();
        CreateMap<CreateAnswerCommand, AnswerEntity>().ReverseMap();
        CreateMap<UpdateAnswerCommand, AnswerEntity>().ReverseMap();
        CreateMap<QuestionEntity, QuestionResponse>().ReverseMap();
        CreateMap<CreateStudentQuestionAttemptCommand, QuestionAttemptEntity>().ReverseMap();
    }
}