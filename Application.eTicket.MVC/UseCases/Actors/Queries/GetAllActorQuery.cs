using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.UseCases.Actors.Responce;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.eTicket.MVC.UseCases.Actors.Queries;
public record GetAllActorQuery : IRequest<List<ActorResponce>>;

public class GetAllActorQueryHandler : IRequestHandler<GetAllActorQuery, List<ActorResponce>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllActorQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ActorResponce>> Handle(GetAllActorQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context.Roles.ToListAsync(cancellationToken);
        var result = _mapper.Map<List<ActorResponce>>(entities);
        return result;
    }
}
