using MediatR;

namespace Application.eTicket.MVC.UseCases.Order.Commands;
public record CreateOrderCommand : IRequest<Ulid>
{
    public Ulid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Ulid>
{
    public Task<Ulid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
