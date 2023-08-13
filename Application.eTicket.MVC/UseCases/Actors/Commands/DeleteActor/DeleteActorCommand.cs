using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Actors.Commands;
public record DeleteActorCommand : IRequest
{
    public Ulid Id { get; set; }
}

public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteActorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteActorCommand request, CancellationToken cancellationToken)
    {
        var producer = await _context.Producers.FindAsync(request.Id);
        if (producer is null)
            throw new NotFoundException(nameof(Producer), request.Id);

        _context.Producers.Remove(producer);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
