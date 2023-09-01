using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Cinemas.Commands;
public record DeleteCinemaCommand : IRequest
{
    public Ulid Id { get; set; }
}

public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCinemaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
    {
        var foundCinema = await _context.Cinemas.FindAsync(request.Id);
        if (foundCinema is null)
            throw new NotFoundException(nameof(Cinema), request.Id);


    }
}
