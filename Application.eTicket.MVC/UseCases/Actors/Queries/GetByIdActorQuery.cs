using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.UseCases.Actors.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Actors.Queries;
public record GetByIdActorQuery : IRequest<ActorResponce>
{
    public Ulid Id { get; set; }
}

public class GetByIdActorQueryHandler : IRequestHandler<GetByIdActorQuery, ActorResponce>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdActorQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ActorResponce> Handle(GetByIdActorQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Actors.FindAsync(request.Id, cancellationToken);
        if (entity is null)
            throw new NotFoundException(nameof(Actor), request.Id);

        var result = _mapper.Map<ActorResponce>(entity);
        return result;
    }
}
