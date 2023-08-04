using FluentValidation;

namespace Application.eTicket.MVC.UseCases.Order.Commands.UpdateOrder;
public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("Order ID is required.");

        RuleFor(command => command.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(command => command.OrderDate)
            .NotEmpty().WithMessage("Order date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Order date must be in the past or present.");

        RuleFor(command => command.IsPaid)
            .NotNull().WithMessage("IsPaid field is required.");
    }
}
