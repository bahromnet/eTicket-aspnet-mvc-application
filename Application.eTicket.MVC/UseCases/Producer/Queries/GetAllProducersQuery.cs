using Application.eTicket.MVC.UseCases.Producer.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Producer.Queries;
public record GetAllProducersQuery : IRequest<List<ProducerResponce>>;

public class GetAllProducersQueryHandler : IRequestHandler<GetAllProducersQuery, List<ProducerResponce>>
{
    public Task<List<ProducerResponce>> Handle(GetAllProducersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
