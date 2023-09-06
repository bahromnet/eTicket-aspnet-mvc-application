using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.UseCases.Movies.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Movies.Queries;
public record GetByIdMovieQuery : IRequest<MovieResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdMovieQueryHandler : IRequestHandler<GetByIdMovieQuery, MovieResponce>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetByIdMovieQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MovieResponce> Handle(GetByIdMovieQuery request, CancellationToken cancellationToken)
    {
        var foundMovie = await _context.Movies.FindAsync(request.Id, cancellationToken);

        if (foundMovie is null)
            throw new NotFoundException(nameof(Movie), request.Id);

        return _mapper.Map<MovieResponce>(foundMovie);
    }
}
