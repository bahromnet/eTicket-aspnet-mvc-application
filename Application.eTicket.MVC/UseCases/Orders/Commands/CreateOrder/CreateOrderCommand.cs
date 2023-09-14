using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.UseCases.OrderItems.Commands;
using Application.eTicket.MVC.UseCases.Orders.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Orders.Commands;
public record CreateOrderCommand : IRequest<Ulid>
{
    public Ulid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }
    public List<MovieOrder> MovieOrders { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Ulid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediatr;

    public CreateOrderCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediatr)
    {
        _context = context;
        _mapper = mapper;
        _mediatr = mediatr;
    }

    public async Task<Ulid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order? orderAfterMapping = _mapper.Map<Order>(request);
        if (orderAfterMapping is not null)
        {
            orderAfterMapping.Id = Ulid.NewUlid();
            foreach (var movieOrder in request.MovieOrders)
            {
                var createOrderItemCommand = new CreateOrderItemCommand
                {
                    OrderId = orderAfterMapping.Id,
                    MovieId = movieOrder.MovieId,
                    SeatNumber = movieOrder.SeatNumber,
                    Price = movieOrder.Price,
                    ScreeningTime = movieOrder.ScreeningTime
                };
                var orderItemId = await _mediatr.Send(createOrderItemCommand, cancellationToken);
                var orderItem = await _context.OrderItems.FindAsync(orderItemId, cancellationToken);
                orderAfterMapping.OrderItems.Add(orderItem);
            }
        }
        await _context.Orders.AddAsync(orderAfterMapping, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return orderAfterMapping.Id;
    }
}
