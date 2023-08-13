using Application.eTicket.MVC.UseCases.Orders.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Orders.Queries;
public record GetByIdOrderQuery : IRequest<OrderResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, OrderResponce>
{
    public Task<OrderResponce> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
