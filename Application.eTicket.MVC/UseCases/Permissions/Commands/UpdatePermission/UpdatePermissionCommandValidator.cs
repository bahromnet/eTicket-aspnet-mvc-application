using FluentValidation;

namespace Application.eTicket.MVC.UseCases.Permissions.Commands.UpdatePermission;
public class UpdatePermissionCommandValidator : AbstractValidator<UpdatePermissionCommand>
{
    public UpdatePermissionCommandValidator()
    {
        RuleFor(x => x.Name)
           .NotNull()
           .NotEmpty().WithMessage("Permission name must not be empty!")
           .MaximumLength(255).WithMessage("Permission name cannot exceed 255 characters.");
    }
}
