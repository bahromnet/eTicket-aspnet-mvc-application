using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.Commons.Models;
using Application.eTicket.MVC.UseCases.Actors.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Actors.Queries;
public record GetAllActorQuery : IRequest<PaginatedList<ActorResponce>>
{
    public string SearchingText { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetAllActorQueryHandler : IRequestHandler<GetAllActorQuery, PaginatedList<ActorResponce>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllActorQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ActorResponce>> Handle(GetAllActorQuery request, CancellationToken cancellationToken)
    {
        int pageNumber = request.PageNumber;
        int pageSize = request.PageSize;
        string searchingText = request.SearchingText.Trim();

        var allActors = _context.Actors.AsQueryable();

        if (!string.IsNullOrEmpty(searchingText))
        {
            allActors = allActors.Where(actor
                => actor.ActorName.ToLower().Contains(searchingText.ToLower())
                || actor.ActorBio.ToLower().Contains(searchingText.ToLower()));
        }

        var paginatedActors = await PaginatedList<Actor>.CreateAsync(allActors, pageNumber, pageSize, cancellationToken);

        var actorsAfterMapping = _mapper.Map<List<ActorResponce>>(paginatedActors.Items);

        var result = new PaginatedList<ActorResponce>(actorsAfterMapping, paginatedActors.TotalCount, pageNumber, pageSize);

        return result;
    }
}
