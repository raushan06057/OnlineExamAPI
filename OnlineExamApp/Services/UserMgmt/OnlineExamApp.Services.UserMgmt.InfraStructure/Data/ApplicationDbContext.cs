namespace OnlineExamApp.Services.UserMgmt.InfraStructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure one-to-one relationship between OrganizationEntity and OrganizationAddressEntity
        builder.Entity<OrganizationEntity>()
            .HasOne(o => o.HeadquartersAddress)
            .WithOne(oa => oa.Organization)
            .HasForeignKey<OrganizationAddressEntity>(oa => oa.OrganizationId);

        // Configure one-to-many relationship between OrganizationEntity and OrgDepartmentEntity
        builder.Entity<OrganizationEntity>()
            .HasMany(o => o.Departments)
            .WithOne(d => d.Organization)
            .HasForeignKey(d => d.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict); // or .OnDelete(DeleteBehavior.NoAction)

        // Configure one-to-many relationship between OrgDepartmentEntity and ApplicationUser
        builder.Entity<OrgDepartmentEntity>()
            .HasMany(d => d.UserList)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict); // or .OnDelete(DeleteBehavior.NoAction)

        // Configure one-to-many relationship between OrganizationEntity and ApplicationUser
        builder.Entity<OrganizationEntity>()
            .HasMany(o => o.Employees)
            .WithOne(e => e.Organization)
            .HasForeignKey(e => e.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict); // or .OnDelete(DeleteBehavior.NoAction)

        builder.Entity<OrgEmployeeEntity>()
            .HasOne(e => e.Department)
            .WithMany(o => o.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<ExamEntity>()
            .HasOne(e => e.Organization)
            .WithMany(o => o.Exams)
            .HasForeignKey(e => e.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ExamAttemptEntity>()
            .HasOne(s=>s.Student)
            .WithMany(ea=>ea.ExamAttempts)
            .HasForeignKey(s=>s.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<StudentInfoEntity>()
            .HasOne(s => s.Department)
            .WithMany(d => d.Students)
            .HasForeignKey(s => s.DepartmentId);

        builder.Entity<StudentInfoEntity>()
            .HasOne(s => s.Guardian)
            .WithMany(d => d.Students)
            .HasForeignKey(s => s.GuardianId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<GuardianInfoEntity>()
           .HasOne(s => s.Organization)
           .WithMany(d => d.GuardianInfos)
           .HasForeignKey(s => s.OrganizationId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<CourseEntity>()
    .HasOne(e => e.Organization)
            .WithMany()
            .HasForeignKey(e => e.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<CourseEnrollmentEntity>()
        //    .HasKey(ce => new { ce.StudentId, ce.CourseId });

        builder.Entity<CourseEnrollmentEntity>()
            .HasOne(ce => ce.Student)
            .WithMany(s => s.CourseEnrollments)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<AttemptAnswerEntity>()
       .Property(aa => aa.IsSelected)
       .HasColumnOrder(3)
       .HasConversion(
           selected => selected ? (byte)1 : (byte)0,
        @selected => @selected != 0);

        builder.Entity<AttemptAnswerEntity>()
            .Property(aa => aa.IsCorrect)
            .HasColumnOrder(4)
            .HasConversion(
                correct => correct ? (byte)1 : (byte)0,
                @correct => @correct != 0);

    }

    public virtual DbSet<OrganizationEntity> Organizations { get; set; }
    public virtual DbSet<OrganizationAddressEntity> OrganizationAddresses { get; set; }
    public virtual DbSet<OrgDepartmentEntity> OrgDepartments { get; set; }
    public virtual DbSet<OrgEmployeeEntity> OrgEmployees { get; set; }
    public virtual DbSet<CourseEntity> Courses { get; set; }
    public virtual DbSet<CourseEnrollmentEntity> CourseEnrollments { get; set; }
    public virtual DbSet<GuardianInfoEntity> Guardians { get; set; }
    public virtual DbSet<StudentInfoEntity> StudentInfos { get; set; }
    public virtual DbSet<ExamEntity> Exams { get; set; }
    public virtual DbSet<QuestionEntity> Questions { get; set; }
    public virtual DbSet<AnswerOptionEntity> AnswerOptions { get; set; }
    public virtual DbSet<ExamAttemptEntity> ExamAttempts { get; set; }
    public virtual DbSet<AnswerEntity> Answers { get; set; }
    public virtual DbSet<QuestionAttemptEntity> QuestionAttempts { get; set; }
    public virtual DbSet<AttemptAnswerEntity> AttemptAnswers { get; set; }
    public virtual DbSet<SubjectEntity> Subjects { get; set; }
}