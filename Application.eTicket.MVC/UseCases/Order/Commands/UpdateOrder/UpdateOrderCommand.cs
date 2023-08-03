using MediatR;

namespace Application.eTicket.MVC.UseCases.Order.Commands;
public record UpdateOrderCommand : IRequest
{
    public Ulid Id { get; set; }
    public Ulid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }
}

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    public Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
