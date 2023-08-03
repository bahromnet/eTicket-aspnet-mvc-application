using Application.eTicket.MVC.UseCases.Order.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Order.Queries;
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
