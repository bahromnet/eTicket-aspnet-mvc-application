using MediatR;

namespace Application.eTicket.MVC.UseCases.Producer.Commands;
public record CreateProducerCommand : IRequest<Ulid>
{
    public string ProducerName { get; set; }
    public string ProducerImage { get; set; }
    public string ProducerBio { get; set; }
}

public class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, Ulid>
{
    public Task<Ulid> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
