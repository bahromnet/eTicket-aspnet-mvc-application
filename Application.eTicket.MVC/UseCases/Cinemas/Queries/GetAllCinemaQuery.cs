using Application.eTicket.MVC.UseCases.Cinemas.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Cinemas.Queries;
public record GetAllCinemaQuery : IRequest<List<CinemaResponce>>;

public class GetAllCinemaQueryHandler : IRequestHandler<GetAllCinemaQuery, List<CinemaResponce>>
{
    public Task<List<CinemaResponce>> Handle(GetAllCinemaQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
