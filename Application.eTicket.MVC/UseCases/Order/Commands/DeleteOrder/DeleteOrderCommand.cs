using MediatR;

namespace Application.eTicket.MVC.UseCases.Order.Commands;
public record DeleteOrderCommand : IRequest
{
    public Ulid Id { get; set; }
}

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    public Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
