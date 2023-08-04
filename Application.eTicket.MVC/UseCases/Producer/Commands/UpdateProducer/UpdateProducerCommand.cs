using MediatR;

namespace Application.eTicket.MVC.UseCases.Producer.Commands;
public record UpdateProducerCommand : IRequest
{
    public Ulid Id { get; set; }
    public string ProducerName { get; set; }
    public string ProducerImage { get; set; }
    public string ProducerBio { get; set; }
}

public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand>
{
    public Task Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
