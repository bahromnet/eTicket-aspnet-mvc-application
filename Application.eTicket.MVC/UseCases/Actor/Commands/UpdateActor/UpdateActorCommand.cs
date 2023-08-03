using MediatR;

namespace Application.eTicket.MVC.UseCases.Actor.Commands;
public record UpdateActorCommand : IRequest
{
    public Ulid Id { get; set; }
    public string ActorName { get; set; }
    public string ActorImage { get; set; }
    public string ActorBio { get; set; }
}

public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand>
{
    public Task Handle(UpdateActorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
