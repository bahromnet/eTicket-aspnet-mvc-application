using MediatR;

namespace Application.eTicket.MVC.UseCases.Actor.Commands;
public record CreateActorCommand : IRequest<Ulid>
{
    public string ActorName { get; set; }
    public string ActorImage { get; set; }
    public string ActorBio { get; set; }
}

public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Ulid>
{
    public Task<Ulid> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
