using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.Commons.Models;
using Application.eTicket.MVC.UseCases.Producers.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Producers.Queries;
public record GetAllProducersQuery : IRequest<PaginatedList<ProducerResponce>>
{
    public string SearchingText { get; }
    public int PageNumber { get; } = 1;
    public int PageSize { get; } = 10;
}

public class GetAllProducersQueryHandler : IRequestHandler<GetAllProducersQuery, PaginatedList<ProducerResponce>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllProducersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProducerResponce>> Handle(GetAllProducersQuery request, CancellationToken cancellationToken)
    {
        int pageNumber = request.PageNumber;
        int pageSize = request.PageSize;
        string searchingText = request.SearchingText.Trim();

        IQueryable<Producer> allProducers = _context.Producers.AsQueryable();

        if (!string.IsNullOrEmpty(searchingText))
        {
            allProducers = allProducers.Where(producer
                => producer.ProducerName.ToLower().Contains(searchingText.ToLower())
                || producer.ProducerBio.ToLower().Contains(searchingText.ToLower()));
        }

        PaginatedList<Producer> paginatedProducer = await PaginatedList<Producer>.CreateAsync(allProducers, pageNumber, pageSize, cancellationToken);
        List<ProducerResponce> producersAfterMapping = _mapper.Map<List<ProducerResponce>>(paginatedProducer.Items);
        var result = new PaginatedList<ProducerResponce>(producersAfterMapping, paginatedProducer.TotalCount, pageNumber, pageSize);
        return result;
    }
}
