using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Producers.Commands;
public record DeleteProducerCommand : IRequest
{
    public Ulid Id { get; }
}

public class DeleteProducerCommandHandler : IRequestHandler<DeleteProducerCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProducerCommandHandler(IApplicationDbContext context)
        => _context = context;

    public async Task Handle(DeleteProducerCommand request, CancellationToken cancellationToken)
    {
        var foundProducer = await _context.Producers.FindAsync(new object[] { request.Id }, cancellationToken)
            ?? throw new NotFoundException(nameof(Producer), request.Id);

        _context.Producers.Remove(foundProducer);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
