using Application.eTicket.MVC.UseCases.Cinema.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Cinema.Queries;
public record GetByIdCinemaQuery : IRequest<CinemaResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdCinemaQueryHandler : IRequestHandler<GetByIdCinemaQuery, CinemaResponce>
{
    public Task<CinemaResponce> Handle(GetByIdCinemaQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
