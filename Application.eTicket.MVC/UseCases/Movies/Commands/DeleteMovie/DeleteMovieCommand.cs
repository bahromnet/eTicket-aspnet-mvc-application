using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Movies.Commands;
public record DeleteMovieCommand : IRequest
{
    public Ulid Id { get; }
}

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var foundMovie = await _context.Movies.FindAsync(new object?[] { request.Id }, cancellationToken) 
            ?? throw new NotFoundException(nameof(Movie), request.Id);

        _context.Movies.Remove(foundMovie);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
