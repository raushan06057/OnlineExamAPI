namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Extesnsions;

public static class InfraService
{
    public static IServiceCollection AddInfraService(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<ApplicationDbContext>(opt =>
        //{
        //    opt.UseSqlServer(
        //        configuration.GetConnectionString(CommonFields.ApplicationUserDBConnection),
        //        mod => mod.MigrationsAssembly("OnlineExamApp.Services.UserMgmt.InfraStructure"));
        //    //opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //});
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddDataProtection();
        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
       .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        //services.AddIdentity<ApplicationUser, ApplicationRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>()
        //    .AddDefaultTokenProviders();
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(
                configuration.GetConnectionString(CommonFields.ApplicationUserDBConnection),
                mod => mod.MigrationsAssembly("OnlineExamApp.Services.UserMgmt.InfraStructure"));
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<SignInManager<ApplicationUser>>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IOrgDepartmentRepository, OrgDepartmentRepository>();
        services.AddScoped<IOrgEmployeeRepository, OrgEmployeeRepository>();
        services.AddScoped<IStudentInfoRepository, StudentInfoRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ISubjectRepository,SubjectRepository>();
        services.AddScoped<ICourseEnrollmentRepository, CourseEnrollmentRepository>();
        services.AddScoped<IGuardianInfoRepository, GuardianInfoRepository>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IAnswerOptionRepository, AnswerOptionRepository>();
        services.AddScoped<IExamAttemptRepository, ExamAttemptRepository>();
        services.AddScoped<IAnswerRepository, AnswerRepository>();
        services.AddScoped<IStudentQuestionAttemptRepository, StudentQuestionAttemptRepository>();
        services.AddScoped<IAttemptAnswersRepository, AttemptAnswersRepository>();
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}