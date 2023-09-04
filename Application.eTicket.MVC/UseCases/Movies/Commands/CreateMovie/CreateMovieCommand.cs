using Application.eTicket.MVC.Commons.Interfaces;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using Domain.eTicket.MVC.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.eTicket.MVC.UseCases.Movies.Commands;
public record CreateMovieCommand : IRequest<Ulid>
{
    public string MovieName { get; }
    public string MovieDescription { get; }
    public decimal MoviePrice { get; }
    public IFormFile? MovieImage { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public MovieCategory MovieCategory { get; }
    public int ProducerId { get; }
}

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Ulid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public CreateMovieCommandHandler(IApplicationDbContext context, IMapper mapper, IConfiguration config)
    {
        _context = context;
        _mapper = mapper;
        _config = config;
    }

    public async Task<Ulid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movieAfterMapping = _mapper.Map<Movie>(request);
        if (movieAfterMapping is not null)
        {
            movieAfterMapping.Id = Ulid.NewUlid();
            movieAfterMapping.MovieName = request.MovieName;
            movieAfterMapping.MovieDescription = request.MovieDescription;
            movieAfterMapping.MoviePrice = request.MoviePrice;
            movieAfterMapping.StartDate = request.StartDate;
            movieAfterMapping.EndDate = request.EndDate;
            movieAfterMapping.MovieCategory = request.MovieCategory;
            movieAfterMapping.ProducerId = request.ProducerId;
            if (movieAfterMapping.MovieImage is not null)
            {
                var movieImageConfig = _config["MovieImages"];
                var movieImageName = movieAfterMapping.Id + Path.GetExtension(request.MovieImage.FileName);
                var movieImagePath = Path.Combine(movieImageConfig, movieImageName);
                using (var fs = new FileStream(movieImagePath, FileMode.Create))
                {
                    await request.MovieImage.CopyToAsync(fs);
                    movieAfterMapping.MovieImage = movieImagePath;
                }
            }
        }
        await _context.Movies.AddAsync(movieAfterMapping, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return movieAfterMapping.Id;
    }
}
