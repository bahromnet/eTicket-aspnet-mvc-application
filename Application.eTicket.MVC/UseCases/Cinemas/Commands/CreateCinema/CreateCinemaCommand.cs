using Application.eTicket.MVC.Commons.Interfaces;
using AutoMapper;
using Castle.Core.Configuration;
using Domain.eTicket.MVC.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

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

        }
        return cinema.Id;
    }
}
