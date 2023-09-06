using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItems.Commands;
public record UpdateOrderItemCommand : IRequest
{
    public Ulid Id { get; set; }
    public Ulid OrderId { get; set; }
    public Ulid MovieId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime ScreeningTime { get; set; }
}

public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOrderItemCommandHandler(IApplicationDbContext context)
        => _context = context;

    public async Task Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var foundOrderItem = await _context.OrderItems.FindAsync(new object[] { request.Id }, cancellationToken)
            ?? throw new NotFoundException(nameof(OrderItem), cancellationToken);

        foundOrderItem.OrderId = request.OrderId;
        foundOrderItem.MovieId = request.MovieId;
        foundOrderItem.SeatNumber = request.SeatNumber;
        foundOrderItem.Price = request.Price;
        foundOrderItem.ScreeningTime = request.ScreeningTime;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
