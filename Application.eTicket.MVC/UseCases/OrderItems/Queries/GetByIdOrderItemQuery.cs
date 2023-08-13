using Application.eTicket.MVC.UseCases.OrderItems.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItems.Queries;
public record GetByIdOrderItemQuery : IRequest<OrderItemResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdOrderItemQueryHandler : IRequestHandler<GetByIdOrderItemQuery, OrderItemResponce>
{
    public Task<OrderItemResponce> Handle(GetByIdOrderItemQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
