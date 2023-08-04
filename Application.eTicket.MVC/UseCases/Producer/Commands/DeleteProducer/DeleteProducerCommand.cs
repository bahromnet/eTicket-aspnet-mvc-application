using MediatR;

namespace Application.eTicket.MVC.UseCases.Producer.Commands;
public record DeleteProducerCommand : IRequest
{
    public Ulid Id { get; set; }
}

public class DeleteProducerCommandHandler : IRequestHandler<DeleteProducerCommand>
{
    public Task Handle(DeleteProducerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
