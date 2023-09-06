using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.eTicket.MVC.UseCases.Users.Commands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full Name is required")
            .MinimumLength(3).WithMessage("Full Name must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Full Name cannot exceed 100 characters");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("User Name is required")
            .MinimumLength(3).WithMessage("User Name must be at least 3 characters long")
            .MaximumLength(100).WithMessage("User Name cannot exceed 100 characters");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone is required");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address");

        RuleFor(x => x.Picture)
            .Must(BeAValidImage).WithMessage("Invalid image format. Only JPG, PNG, and JPEG formats are allowed.")
            .Must(BeAValidImageSize).WithMessage("Image size must not exceed 5MB.")
            .WithMessage("Invalid picture URL format");

        RuleFor(x => x.Roles)
            .Must(BeValidRoleNames).When(x => x.Roles != null && x.Roles.Count > 0)
            .WithMessage("Invalid role names");
    }

    private bool BeAValidImage(IFormFile filePath)
    {
        if (string.IsNullOrEmpty(filePath.FileName))
            return false;

        var allowedFormats = new[] { ".jpg", ".jpeg", ".png" };
        var ext = Path.GetExtension(filePath.FileName);
        return allowedFormats.Contains(ext, StringComparer.OrdinalIgnoreCase);
    }

    private bool BeAValidImageSize(IFormFile filePath)
    {
        if (string.IsNullOrEmpty(filePath.FileName))
            return false;

        const int maxSize = 5 * 1024 * 1024; // 5MB
        var fileInfo = new FileInfo(filePath.FileName);
        return fileInfo.Length <= maxSize;
    }

    private bool BeValidRoleNames(List<string> roles)
    {
        return roles.All(role => !string.IsNullOrWhiteSpace(role));
    }
}
