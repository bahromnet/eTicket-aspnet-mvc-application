using FluentValidation;

namespace Application.eTicket.MVC.UseCases.Permissions.Commands.CreatePermission;
public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionCommandValidator()
    {
        RuleFor(x => x.Name)
                .Must(BeUniqueNames).WithMessage("Permission names must be unique.")
                .ForEach(name =>
                {
                    name.NotEmpty().WithMessage("Permission name must not be empty!")
                        .MaximumLength(255).WithMessage("Permission name cannot exceed 255 characters.");
                });
    }
    private bool BeUniqueNames(string[] names)
    {
        return names.Distinct().Count() == names.Length;
    }
}
