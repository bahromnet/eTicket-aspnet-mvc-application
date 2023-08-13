using MediatR;

namespace Application.eTicket.MVC.UseCases.Permissions.Commands.DeletePermission;
public record DeletePermissionCommand : IRequest
{
    public Ulid Id { get; }
}

public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand>
{
    public Task Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
