using Application.eTicket.MVC.Commons.Interfaces;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.eTicket.MVC.UseCases.Cinemas.Commands;
public record CreateCinemaCommand : IRequest<Ulid>
{
    public string CinemaName { get; set; }
    public string CinemaDescription { get; set; }
    public IFormFile? CinemaLogo { get; set; }
    public string CinemaLocation { get; set; }
}

public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, Ulid>
{
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;

    public CreateCinemaCommandHandler(IApplicationDbContext context, IConfiguration config, IMapper mapper)
    {
        _context = context;
        _config = config;
        _mapper = mapper;
    }

    public async Task<Ulid> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinema = _mapper.Map<Cinema>(request);
        if (cinema is not null)
        {
            cinema.Id = Ulid.NewUlid();
            cinema.CinemaName = request.CinemaName;
            cinema.CinemaDescription = request.CinemaDescription;
            cinema.CinemaLocation = request.CinemaLocation;

            var cinemaLogoConfig = _config["CinemaImages"];
            var cinemaLogoName = cinema.Id + Path.GetExtension(request.CinemaLogo.FileName);
            var cinemaLogoPath = Path.Combine(cinemaLogoConfig, cinemaLogoName);
            using (var fs = new FileStream(cinemaLogoPath, FileMode.Create))
            {
                await request.CinemaLogo.CopyToAsync(fs);
                cinema.CinemaLogo = cinemaLogoPath;
            }
        }
        await _context.Cinemas.AddAsync(cinema, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cinema.Id;
    }
}
