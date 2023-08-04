using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItem.Commands;
public record DeleteOrderItemCommand : IRequest
{
    public Ulid Id { get; set; }
}

public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand>
{
    public Task Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
