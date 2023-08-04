using Application.eTicket.MVC.UseCases.OrderItem.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItem.Queries;
public record GetAllOrderItemsQuery : IRequest<List<OrderItemResponce>>;

public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, List<OrderItemResponce>>
{
    public Task<List<OrderItemResponce>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
