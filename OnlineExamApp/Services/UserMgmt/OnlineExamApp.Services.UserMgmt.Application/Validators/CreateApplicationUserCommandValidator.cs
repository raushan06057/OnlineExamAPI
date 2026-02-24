namespace OnlineExamApp.Services.UserMgmt.Application.Validators;

public class CreateApplicationUserCommandValidator : AbstractValidator<CreateApplicationUserCommand>
{
    public CreateApplicationUserCommandValidator()
    {
        RuleFor(mod=>mod.UserName).NotEmpty()
            .WithMessage("{UserName} is required")
            .NotNull()
            .MaximumLength(70)
            .WithMessage("{UserName} must not exceed 70 characters");

        RuleFor(mod => mod.Email).NotEmpty()
            .WithMessage("{Email} is required")
            .NotNull()
            .MaximumLength(70)
            .WithMessage("{Email} must not exceed 70 characters");

        RuleFor(mod => mod.Pwd).NotEmpty()
            .WithMessage("{Pwd} is required")
            .NotNull()
            .MinimumLength(8)
            .WithMessage("{Pwd} must not less than 8 characters")
            .NotNull()
            .MaximumLength(15)
            .WithMessage("{Pwd} must not exceed 15 characters");
        RuleFor(mod => mod.OrganizationId)
            .NotEmpty().NotNull().WithErrorCode("{{OrganizationId}} must not be null")
            .NotEqual(0).WithErrorCode("{{OrganizationId}} must not be zero.");
        
    }
}
