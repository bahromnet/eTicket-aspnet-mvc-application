using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.UseCases.OrderItems.Commands;
using Application.eTicket.MVC.UseCases.Orders.Responce;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Orders.Commands;
public record UpdateOrderCommand : IRequest
{
    public Ulid Id { get; set; }
    public Ulid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }
    public List<MovieOrder> MovieOrders { get; set; }
}

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediatr;

    public UpdateOrderCommandHandler(IApplicationDbContext context, IMediator mediatr)
    {
        _context = context;
        _mediatr = mediatr;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var foundOrder = await _context.Orders.FindAsync(new object[] { request.Id, cancellationToken }, cancellationToken)
            ?? throw new NotFoundException(nameof(Order), request.Id);

        if (foundOrder is not null)
        {
            foundOrder.Id = Ulid.NewUlid();
            foreach (var movieOrder in request.MovieOrders)
            {
                var createOrderItemCommand = new CreateOrderItemCommand
                {
                    OrderId = foundOrder.Id,
                    MovieId = movieOrder.MovieId,
                    SeatNumber = movieOrder.SeatNumber,
                    Price = movieOrder.Price,
                    ScreeningTime = movieOrder.ScreeningTime
                };
                var orderItemId = await _mediatr.Send(createOrderItemCommand, cancellationToken);
                var orderItem = await _context.OrderItems.FindAsync(new object?[] { orderItemId, cancellationToken }, cancellationToken);
                foundOrder.OrderItems.Add(orderItem);
            }
        }
        await _context.Orders.AddAsync(foundOrder, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
