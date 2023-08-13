using FluentValidation;

namespace Application.eTicket.MVC.UseCases.OrderItems.Commands.UpdateOrderItem;
public class UpdateOrderItemCommandValidator : AbstractValidator<UpdateOrderItemCommand>
{
    public UpdateOrderItemCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("OrderItem ID is required.");

        RuleFor(command => command.OrderId)
            .NotEmpty().WithMessage("Order ID is required.");

        RuleFor(command => command.MovieId)
            .NotEmpty().WithMessage("Movie ID is required.");

        RuleFor(command => command.SeatNumber)
            .GreaterThan(0).WithMessage("Seat number must be greater than 0.");

        RuleFor(command => command.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(command => command.ScreeningTime)
            .NotEmpty().WithMessage("Screening time is required.")
            .GreaterThan(DateTime.UtcNow).WithMessage("Screening time must be in the future.");
    }
}
