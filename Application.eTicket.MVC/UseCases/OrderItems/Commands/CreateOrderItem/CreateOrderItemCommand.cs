using Application.eTicket.MVC.Commons.Interfaces;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItems.Commands;
public record CreateOrderItemCommand : IRequest<Ulid>
{
    public Ulid OrderId { get; set; }
    public Ulid MovieId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime ScreeningTime { get; set; }
}

public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, Ulid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateOrderItemCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Ulid> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        OrderItem orderItemAfterMapping = _mapper.Map<OrderItem>(request);
        if (orderItemAfterMapping is not null)
        {
            orderItemAfterMapping.Id = Ulid.NewUlid();
            orderItemAfterMapping.OrderId = request.OrderId;
            orderItemAfterMapping.MovieId = request.MovieId;
            orderItemAfterMapping.SeatNumber = request.SeatNumber;
            orderItemAfterMapping.Price = request.Price;
            orderItemAfterMapping.ScreeningTime = request.ScreeningTime;
        }
        await _context.OrderItems.AddAsync(orderItemAfterMapping, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return orderItemAfterMapping.Id;
    }
}
