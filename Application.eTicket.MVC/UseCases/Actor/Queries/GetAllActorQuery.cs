using Application.eTicket.MVC.UseCases.Actor.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Actor.Queries;
public record GetAllActorQuery : IRequest<List<ActorResponce>>;

public class GetAllActorQueryHandler : IRequestHandler<GetAllActorQuery, List<ActorResponce>>
{
    public Task<List<ActorResponce>> Handle(GetAllActorQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
