using Application.eTicket.MVC.UseCases.Producer.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Producer.Queries;
public record GetByIdProducerQuery : IRequest<ProducerResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdProducerQueryHandler : IRequestHandler<GetByIdProducerQuery, ProducerResponce>
{
    public Task<ProducerResponce> Handle(GetByIdProducerQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
