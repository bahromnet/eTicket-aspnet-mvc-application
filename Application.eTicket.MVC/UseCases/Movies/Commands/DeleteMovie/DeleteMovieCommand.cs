using MediatR;

namespace Application.eTicket.MVC.UseCases.Movies.Commands;
public record DeleteMovieCommand : IRequest
{
    public Ulid Id { get; }
}

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    public Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
