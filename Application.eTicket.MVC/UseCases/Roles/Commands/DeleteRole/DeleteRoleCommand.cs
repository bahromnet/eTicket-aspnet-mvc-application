using MediatR;

namespace Application.eTicket.MVC.UseCases.Roles.Commands.DeleteRole;
public record DeleteRoleCommand : IRequest
{
    public Ulid Id { get; }
}

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    public Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
