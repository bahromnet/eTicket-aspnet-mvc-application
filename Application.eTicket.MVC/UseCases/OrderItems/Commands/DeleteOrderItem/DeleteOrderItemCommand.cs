using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItems.Commands;
public record DeleteOrderItemCommand : IRequest
{
    public Ulid Id { get; set; }
}

public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteOrderItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        var foundOrderItem = await _context.OrderItems.FindAsync(new object[] { request.Id }, cancellationToken)
            ?? throw new NotFoundException(nameof(OrderItem), request.Id);

        _context.OrderItems.Remove(foundOrderItem);
        await _context.SaveChangesAsync(cancellationToken);
            
    }
}
