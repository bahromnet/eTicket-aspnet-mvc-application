using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.eTicket.MVC.UseCases.Cinemas.Commands;
public record CreateCinemaCommand : IRequest<Ulid>
{
    public string CinemaName { get; set; }
    public string CinemaDescription { get; set; }
    public IFormFile? CinemaLogo { get; set; }
    public string CinemaLocation { get; set; }
}

public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, Ulid>
{
    public Task<Ulid> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
