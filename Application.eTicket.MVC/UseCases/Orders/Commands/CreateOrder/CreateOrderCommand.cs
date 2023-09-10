using Application.eTicket.MVC.Commons.Interfaces;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Orders.Commands;
public record CreateOrderCommand : IRequest<Ulid>
{
    public Ulid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }
    public List<Ulid> MovieIds { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Ulid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<Ulid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order orderAfterMapping = _mapper.Map<Order>(request);

    }
}
