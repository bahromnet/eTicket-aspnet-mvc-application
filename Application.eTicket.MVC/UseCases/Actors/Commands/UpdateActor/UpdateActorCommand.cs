using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.eTicket.MVC.UseCases.Actors.Commands;
public record UpdateActorCommand : IRequest
{
    public Ulid Id { get; }
    public string ActorName { get; }
    public IFormFile ActorImage { get; }
    public string ActorBio { get; }
}

public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public UpdateActorCommandHandler(IApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task Handle(UpdateActorCommand request, CancellationToken cancellationToken)
    {
        var actor = await _context.Actors.FindAsync(request.Id);
        if (actor is null)
            throw new NotFoundException(nameof(Actor), request.Id);

        actor.ActorName = request.ActorName;
        actor.ActorBio = request.ActorBio;

        var actorImage = _configuration["ActorImages"];
        string fileName = actor.Id + Path.GetExtension(request.ActorImage.FileName);
        string actorImagePath = Path.Combine(actorImage, fileName);
        using (var fs = new FileStream(actorImagePath, FileMode.Create))
        {
            await request.ActorImage.CopyToAsync(fs);
            actor.ActorImage = actorImagePath;
        };

        await _context.SaveChangesAsync(cancellationToken);
    }
}
