using MediatR;

namespace Application.eTicket.MVC.UseCases.Cinemas.Commands;
public record CreateCinemaCommand : IRequest<Ulid>
{
    public string CinemaName { get; set; }
    public string CinemaDescription { get; set; }
    public string CinemaLogo { get; set; }
    public string CinemaLocation { get; set; }
}

public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, Ulid>
{
    public Task<Ulid> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
