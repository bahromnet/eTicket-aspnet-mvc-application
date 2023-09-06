using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.Commons.Models;
using Application.eTicket.MVC.UseCases.Movies.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Movies.Queries;
public record GetAllMoviesQuery : IRequest<PaginatedList<MovieResponce>>
{
    public int PageNumber { get; } = 1;
    public int PageSize { get; } = 10;
    public string? SearchingText { get; }
}

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, PaginatedList<MovieResponce>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllMoviesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<MovieResponce>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        int pageNumber = request.PageNumber;
        int pageSize = request.PageSize;
        string searchingText = request.SearchingText.Trim();

        var allMovies = _context.Movies.AsQueryable();

        if (!string.IsNullOrEmpty(searchingText))
        {
            allMovies = allMovies.Where(movie
                => movie.MovieName.ToLower().Contains(searchingText.ToLower())
                || movie.MovieDescription.ToLower().Contains(searchingText.ToLower())
                || movie.MovieCategory.ToString().Contains(searchingText)
                || movie.MoviePrice.ToString().Contains(searchingText)
                || movie.StartDate.ToString().Contains(searchingText)
                || movie.EndDate.ToString().Contains(searchingText));
        }

        var paginatedMovies = await PaginatedList<Movie>.CreateAsync(allMovies, pageNumber, pageSize, cancellationToken);

        var paginatedMoviesAfterMapping = _mapper.Map<List<MovieResponce>>(paginatedMovies.Items);

        var response = new PaginatedList<MovieResponce>(paginatedMoviesAfterMapping, paginatedMovies.TotalCount, pageNumber, pageSize);

        return response;
    }
}
