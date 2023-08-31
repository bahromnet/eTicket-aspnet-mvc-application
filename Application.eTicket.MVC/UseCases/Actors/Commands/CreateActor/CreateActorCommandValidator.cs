using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.eTicket.MVC.UseCases.Actors.Commands.CreateActor;
public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
{
    public CreateActorCommandValidator()
    {
        RuleFor(command => command.ActorName)
            .NotEmpty().WithMessage("Actor name is required.")
            .MaximumLength(100).WithMessage("Actor name must not exceed 100 characters.");

        RuleFor(command => command.ActorBio)
            .NotEmpty().WithMessage("Actor bio is required.")
            .MaximumLength(500).WithMessage("Actor bio must not exceed 500 characters.");

        RuleFor(command => command.ActorImage)
            .NotNull().WithMessage("Actor image is required.")
            .Must(BeAValidImage).WithMessage("Invalid image format. Only JPG, PNG, and JPEG formats are allowed.")
            .Must(BeAValidImageSize).WithMessage("Image size must not exceed 5MB.");
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
}
