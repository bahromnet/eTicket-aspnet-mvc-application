using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Orders.Commands;
public record DeleteOrderCommand : IRequest
{
    public Ulid Id { get; set; }
}

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteOrderCommandHandler(IApplicationDbContext context)
        => _context = context;

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var foundOrder = await _context.Orders.FindAsync(new object?[] { request.Id, cancellationToken }, cancellationToken)
            ?? throw new NotFoundException(nameof(Order), request.Id);

        _context.Orders.Remove(foundOrder);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
