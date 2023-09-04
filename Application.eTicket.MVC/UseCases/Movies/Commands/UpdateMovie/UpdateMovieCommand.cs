using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using Domain.eTicket.MVC.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.eTicket.MVC.UseCases.Movies.Commands;
public record UpdateMovieCommand : IRequest
{
    public Ulid Id { get; }
    public string MovieName { get; }
    public string MovieDescription { get; }
    public decimal MoviePrice { get; }
    public IFormFile? MovieImage { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public MovieCategory MovieCategory { get; }
    public int ProducerId { get; }
}

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public UpdateMovieCommandHandler(IApplicationDbContext context, IMapper mapper, IConfiguration config)
    {
        _context = context;
        _mapper = mapper;
        _config = config;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var foundMovie = await _context.Movies.FindAsync(new object?[] { request.Id }, cancellationToken) 
            ?? throw new NotFoundException(nameof(Movie), request.Id);

        foundMovie.MovieName = request.MovieName;
        foundMovie.MovieDescription = request.MovieDescription;
        foundMovie.MoviePrice = request.MoviePrice;
        foundMovie.StartDate = request.StartDate;
        foundMovie.EndDate = request.EndDate;
        foundMovie.MovieCategory = request.MovieCategory;
        foundMovie.ProducerId = request.ProducerId;
        if (foundMovie.MovieImage is not null)
        {
            var movieImageConfig = _config["MovieImages"];
            var movieImageName = foundMovie.Id + Path.GetExtension(request.MovieImage.FileName);
            var movieImagePath = Path.Combine(movieImageConfig, movieImageName);
            using (var fs = new FileStream(movieImagePath, FileMode.Create))
            {
                await request.MovieImage.CopyToAsync(fs);
                foundMovie.MovieImage = movieImagePath;
            }
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}
