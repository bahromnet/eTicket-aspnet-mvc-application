using Domain.eTicket.MVC.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

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
    public Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
