using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.eTicket.MVC.UseCases.Producers.Commands;
public record UpdateProducerCommand : IRequest
{
    public Ulid Id { get; }
    public string ProducerName { get; }
    public IFormFile? ProducerImage { get; }
    public string ProducerBio { get; }
}

public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand>
{
    public Task Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
