using MediatR;

namespace Application.eTicket.MVC.UseCases.Permissions.Commands.UpdatePermission;
public record UpdatePermissionCommand : IRequest
{
    public Ulid Id { get; }
    public string Name { get; }
}

public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand>
{
    public Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
