using Application.eTicket.MVC.Commons.Interfaces;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Application.eTicket.MVC.UseCases.Actors.Commands;
public record CreateActorCommand : IRequest<Ulid>
{
    public string ActorName { get; }
    public IFormFile? ActorImage { get; }
    public string ActorBio { get; }
}

public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Ulid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public CreateActorCommandHandler(IMapper mapper, IApplicationDbContext context, IConfiguration configuration)
    {
        _mapper = mapper;
        _context = context;
        _configuration = configuration;
    }

    public async Task<Ulid> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        var actor = _mapper.Map<Actor>(request);
        if (request.ActorImage is not null)
        {
            actor.Id = Ulid.NewUlid();
            var actorImage = _configuration["ActorImages"];
            string fileName = actor.Id + Path.GetExtension(request.ActorImage.FileName);
            string actorImagePath = Path.Combine(actorImage, fileName);
            using (var fs = new FileStream(actorImagePath, FileMode.Create))
            {
                await request.ActorImage.CopyToAsync(fs);
                actor.ActorImage = actorImagePath;
            };
            actor.ActorBio = request.ActorBio;
        }
        await _context.Actors.AddAsync(actor, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return actor.Id;
    }
}
