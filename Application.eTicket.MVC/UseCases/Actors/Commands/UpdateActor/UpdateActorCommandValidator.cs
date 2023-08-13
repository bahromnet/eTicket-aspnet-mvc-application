using FluentValidation;

namespace Application.eTicket.MVC.UseCases.Actors.Commands.UpdateActor;
public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
{
    public UpdateActorCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("Actor ID is required.");

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

    private bool BeAValidImage(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return false;

        var allowedFormats = new[] { ".jpg", ".jpeg", ".png" };
        var ext = Path.GetExtension(filePath);
        return allowedFormats.Contains(ext, StringComparer.OrdinalIgnoreCase);
    }

    private bool BeAValidImageSize(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return false;

        const int maxSize = 5 * 1024 * 1024; // 5MB
        var fileInfo = new FileInfo(filePath);
        return fileInfo.Length <= maxSize;
    }
}
