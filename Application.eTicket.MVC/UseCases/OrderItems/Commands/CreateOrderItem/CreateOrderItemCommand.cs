using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItems.Commands;
public record CreateOrderItemCommand : IRequest<Ulid>
{
    public Ulid OrderId { get; set; }
    public Ulid MovieId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime ScreeningTime { get; set; }
}

public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, Ulid>
{
    public Task<Ulid> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
