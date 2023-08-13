using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.eTicket.MVC.UseCases.Actor.Commands;
public record CreateActorCommand : IRequest<Ulid>
{
    public string ActorName { get; }
    public IFormFile? ActorImage { get; }
    public string ActorBio { get; }
}

public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Ulid>
{
    public Task<Ulid> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
