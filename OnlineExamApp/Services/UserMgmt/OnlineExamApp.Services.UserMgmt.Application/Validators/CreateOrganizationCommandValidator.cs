namespace OnlineExamApp.Services.UserMgmt.Application.Validators;

public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
    public CreateOrganizationCommandValidator()
    {
        RuleFor(mod => mod.Name).NotEmpty()
            .WithMessage("{Name} is required")
            .NotNull()
            .MaximumLength(70)
            .WithMessage("{Name} must not exceed 70 characters");
    }
}