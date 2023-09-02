using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.eTicket.MVC.UseCases.Cinemas.Commands;
public record UpdateCinemaCommand : IRequest
{
    public Ulid Id { get; }
    public string CinemaName { get; }
    public string CinemaDescription { get; }
    public IFormFile? CinemaLogo { get; }
    public string CinemaLocation { get; }
}

public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _config;

    public UpdateCinemaCommandHandler(IApplicationDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        var foundCinema = await _context.Cinemas.FindAsync(request.Id);
        if (foundCinema is null)
            throw new NotFoundException(nameof(Cinema), request.Id);

        foundCinema.CinemaName = request.CinemaName;
        foundCinema.CinemaDescription = request.CinemaDescription;
        if (request.CinemaLogo is not null)
        {
            var cinemaLogoConfig = _config["CinemaImages"];
            string cinemaLogoName = request.Id + Path.GetExtension(request.CinemaLogo.FileName);
            string cinemaLogoPath = Path.Combine(cinemaLogoConfig, cinemaLogoName);
            using (var fs = new FileStream(cinemaLogoPath, FileMode.Create))
            {
                await request.CinemaLogo.CopyToAsync(fs);
                foundCinema.CinemaLogo = cinemaLogoPath;
            }
        }
    }
}
