using Domain.eTicket.MVC.Entities.Identity;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Role.Commands.CreateRole;
public record CreateRoleCommand : IRequest<Ulid>
{
    public string Name { get; }
    public ICollection<Permission>? Permissions { get; }
}

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Ulid>
{
    public Task<Ulid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
