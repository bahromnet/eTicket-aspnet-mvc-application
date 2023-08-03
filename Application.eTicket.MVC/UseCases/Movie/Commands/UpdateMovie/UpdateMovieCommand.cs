using Domain.eTicket.MVC.Enums;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Movie.Commands;
public record UpdateMovieCommand : IRequest
{
    public Ulid Id { get; set; }
    public string MovieName { get; set; }
    public string MovieDescription { get; set; }
    public decimal MoviePrice { get; set; }
    public string MovieImage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public MovieCategory MovieCategory { get; set; }
    public int ProducerId { get; set; }
}

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    public Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
