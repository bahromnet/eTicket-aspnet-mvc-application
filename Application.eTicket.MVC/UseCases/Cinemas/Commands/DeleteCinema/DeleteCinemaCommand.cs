using MediatR;

namespace Application.eTicket.MVC.UseCases.Cinemas.Commands;
public record DeleteCinemaCommand : IRequest
{
    public Ulid Id { get; set; }
}

public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand>
{
    public Task Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
