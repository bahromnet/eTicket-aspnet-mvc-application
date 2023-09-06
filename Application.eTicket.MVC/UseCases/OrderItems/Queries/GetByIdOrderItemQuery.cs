using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.UseCases.OrderItems.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItems.Queries;
public record GetByIdOrderItemQuery : IRequest<OrderItemResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdOrderItemQueryHandler : IRequestHandler<GetByIdOrderItemQuery, OrderItemResponce>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdOrderItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OrderItemResponce> Handle(GetByIdOrderItemQuery request, CancellationToken cancellationToken)
    {
        var foundOrderItem = await _context.OrderItems.FindAsync(new object[] { request.Id }, cancellationToken)
            ?? throw new NotFoundException(nameof(OrderItem), request.Id);

        return _mapper.Map<OrderItemResponce>(request);
    }
}
