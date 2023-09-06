using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.UseCases.Producers.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Producers.Queries;
public record GetByIdProducerQuery : IRequest<ProducerResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdProducerQueryHandler : IRequestHandler<GetByIdProducerQuery, ProducerResponce>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdProducerQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProducerResponce> Handle(GetByIdProducerQuery request, CancellationToken cancellationToken)
    {
        Producer foundProducer = await _context.Producers.FindAsync(new object[] { request.Id }, cancellationToken)
            ?? throw new NotFoundException(nameof(Producer), request.Id);

        return _mapper.Map<ProducerResponce>(foundProducer);
    }
}
