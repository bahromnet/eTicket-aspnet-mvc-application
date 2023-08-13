using MediatR;

namespace Application.eTicket.MVC.UseCases.Permissions.Commands.CreatePermission;
public record CreatePermissionCommand : IRequest<Ulid>
{
    public string[] Name { get; }
}

public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, Ulid>
{
    public Task<Ulid> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
