using MediatR;

namespace Application.eTicket.MVC.UseCases.Producers.Commands;
public record DeleteProducerCommand : IRequest
{
    public Ulid Id { get; }
}

public class DeleteProducerCommandHandler : IRequestHandler<DeleteProducerCommand>
{
    public Task Handle(DeleteProducerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
