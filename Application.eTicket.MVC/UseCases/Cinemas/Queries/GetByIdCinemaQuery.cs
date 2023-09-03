using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.UseCases.Cinemas.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Cinemas.Queries;
public record GetByIdCinemaQuery : IRequest<CinemaResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdCinemaQueryHandler : IRequestHandler<GetByIdCinemaQuery, CinemaResponce>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdCinemaQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CinemaResponce> Handle(GetByIdCinemaQuery request, CancellationToken cancellationToken)
    {
        var foundCinema = await _context.Cinemas.FindAsync(request.Id);
        if (foundCinema is null)
            throw new NotFoundException(nameof(Cinema), request.Id);

        return _mapper.Map<CinemaResponce>(foundCinema);
    }
}
