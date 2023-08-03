using Application.eTicket.MVC.UseCases.Movie.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Movie.Queries;
public record GetAllMoviesQuery : IRequest<List<MovieResponce>>;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieResponce>>
{
    public Task<List<MovieResponce>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
