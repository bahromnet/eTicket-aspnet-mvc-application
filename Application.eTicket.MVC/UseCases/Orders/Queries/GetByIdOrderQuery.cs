using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.UseCases.Orders.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Orders.Queries;
public record GetByIdOrderQuery : IRequest<OrderResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, OrderResponce>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdOrderQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OrderResponce> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
    {
        var foundOrder = await _context.Orders.FindAsync(new object[] { request.Id, cancellationToken }, cancellationToken)
            ?? throw new NotFoundException(nameof(Order), request.Id);

        return _mapper.Map<OrderResponce>(foundOrder);
    }
}
