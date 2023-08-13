using MediatR;

namespace Application.eTicket.MVC.UseCases.User.Commands.UpdateUser;
public record UpdateUserCommand : IRequest
{
    public Ulid Id { get; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
