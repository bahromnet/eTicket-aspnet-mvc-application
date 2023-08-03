using MediatR;

namespace Application.eTicket.MVC.UseCases.Movie.Commands;
public record DeleteMovieCommand : IRequest
{
    public Ulid Id { get; set; }
}

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    public Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
