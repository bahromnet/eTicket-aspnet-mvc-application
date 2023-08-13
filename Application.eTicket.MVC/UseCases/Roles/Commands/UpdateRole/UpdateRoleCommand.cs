using Domain.eTicket.MVC.Entities.Identity;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Roles.Commands.UpdateRole;
public record UpdateRoleCommand : IRequest
{
    public Ulid Id { get; }
    public string Name { get; }
    public ICollection<Permission>? Permissions { get; }
}

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
{
    public Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
