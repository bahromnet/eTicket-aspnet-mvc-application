using Application.eTicket.MVC.UseCases.OrderItems.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItems.Queries;
public record GetAllOrderItemsQuery : IRequest<List<OrderItemResponce>>;

public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, List<OrderItemResponce>>
{
    public Task<List<OrderItemResponce>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
