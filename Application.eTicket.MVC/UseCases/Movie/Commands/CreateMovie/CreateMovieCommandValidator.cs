using FluentValidation;

namespace Application.eTicket.MVC.UseCases.Movie.Commands.CreateMovie;
public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(command => command.MovieName)
            .NotEmpty().WithMessage("Movie name is required.")
            .MaximumLength(100).WithMessage("Movie name must not exceed 100 characters.");

        RuleFor(command => command.MovieDescription)
            .NotEmpty().WithMessage("Movie description is required.")
            .MaximumLength(500).WithMessage("Movie description must not exceed 500 characters.");

        RuleFor(command => command.MoviePrice)
            .GreaterThan(0).WithMessage("Movie price must be greater than 0.");

        RuleFor(command => command.MovieImage)
            .Must(BeAValidImage).WithMessage("Invalid image format. Only JPG, PNG, and JPEG formats are allowed.")
            .Must(BeAValidImageSize).WithMessage("Image size must not exceed 5MB.");

        RuleFor(command => command.StartDate)
            .NotEmpty().WithMessage("Start date is required.")
            .Must((command, startDate) => startDate < command.EndDate).WithMessage("Start date must be before end date.");

        RuleFor(command => command.EndDate)
            .NotEmpty().WithMessage("End date is required.")
            .Must((command, endDate) => endDate > command.StartDate).WithMessage("End date must be after start date.");

        RuleFor(command => command.MovieCategory)
            .NotEmpty().WithMessage("Movie category is required.");

        RuleFor(command => command.ProducerId)
            .NotEmpty().WithMessage("Producer ID is required.");
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
