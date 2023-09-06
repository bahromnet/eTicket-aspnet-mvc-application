using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.Commons.Models;
using Application.eTicket.MVC.UseCases.Cinemas.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Cinemas.Queries;
public record GetAllCinemaQuery : IRequest<PaginatedList<CinemaResponce>>
{
    public string? SearchingText { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetAllCinemaQueryHandler : IRequestHandler<GetAllCinemaQuery, PaginatedList<CinemaResponce>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCinemaQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CinemaResponce>> Handle(GetAllCinemaQuery request, CancellationToken cancellationToken)
    {
        var pageNumber = request.PageNumber;
        var pageSize = request.PageSize;
        var searchingText = request.SearchingText?.Trim();

        var allCinemas = _context.Cinemas.AsQueryable();

        if (!string.IsNullOrEmpty(searchingText))
        {
            allCinemas = allCinemas.Where(cinema 
                => cinema.CinemaName.ToLower().Contains(searchingText.ToLower())
                || cinema.CinemaDescription.ToLower().Contains(searchingText.ToLower()));
        }

        var paginatedCiemas = await PaginatedList<Cinema>.CreateAsync(allCinemas, pageNumber, pageSize, cancellationToken);

        var cinemaResponseMap = _mapper.Map<List<CinemaResponce>>(paginatedCiemas.Items);

        var responce = new PaginatedList<CinemaResponce>(cinemaResponseMap, paginatedCiemas.TotalCount, pageNumber, pageSize);

        return responce;
    }
}
