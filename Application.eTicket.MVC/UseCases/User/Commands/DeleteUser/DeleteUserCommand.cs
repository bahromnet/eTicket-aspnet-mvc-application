using MediatR;

namespace Application.eTicket.MVC.UseCases.User.Commands.DeleteUser;
public record DeleteUserCommand : IRequest
{
    public Ulid Id { get; }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
