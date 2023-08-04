using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItem.Commands;
public record UpdateOrderItemCommand : IRequest
{
    public Ulid Id { get; set; }
    public Ulid OrderId { get; set; }
    public Ulid MovieId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime ScreeningTime { get; set; }
}

public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand>
{
    public Task Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
