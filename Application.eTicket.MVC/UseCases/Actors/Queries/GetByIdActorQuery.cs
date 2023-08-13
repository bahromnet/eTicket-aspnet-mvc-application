using Application.eTicket.MVC.UseCases.Actors.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Actors.Queries;
public record GetByIdActorQuery : IRequest<ActorResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdActorQueryHandler : IRequestHandler<GetByIdActorQuery, ActorResponce>
{
    public Task<ActorResponce> Handle(GetByIdActorQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
