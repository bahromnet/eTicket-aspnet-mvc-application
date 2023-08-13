using Application.eTicket.MVC.UseCases.Roles.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Roles.Queries;
public record GetByIdRoleQuery : IRequest<RoleResponce>
{
    public Ulid Id { get; }
}

public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQuery, RoleResponce>
{
    public Task<RoleResponce> Handle(GetByIdRoleQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
