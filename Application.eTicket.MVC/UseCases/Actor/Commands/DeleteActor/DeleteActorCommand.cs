using MediatR;

namespace Application.eTicket.MVC.UseCases.Actor.Commands;
public record DeleteActorCommand : IRequest
{
    public Ulid Id { get; set; }
}

public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
{
    public Task Handle(DeleteActorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
