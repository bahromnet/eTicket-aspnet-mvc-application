using Application.eTicket.MVC.UseCases.Cinema.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Cinema.Commands;
public record UpdateCinemaCommand : IRequest
{
    public Ulid Id { get; set; }
    public string CinemaName { get; set; }
    public string CinemaDescription { get; set; }
    public string CinemaLogo { get; set; }
    public string CinemaLocation { get; set; }
}

public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand>
{
    public Task Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
