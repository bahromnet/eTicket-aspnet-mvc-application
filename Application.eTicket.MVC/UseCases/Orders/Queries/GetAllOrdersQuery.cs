using Application.eTicket.MVC.UseCases.Orders.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Orders.Queries;
public record GetAllOrdersQuery : IRequest<List<OrderResponce>>;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderResponce>>
{
    public Task<List<OrderResponce>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
