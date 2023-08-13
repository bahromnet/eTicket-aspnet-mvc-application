using Application.eTicket.MVC.UseCases.Roles.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Roles.Queries;
public record GetAllRolesQuery : IRequest<List<RoleResponce>>;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleResponce>>
{
    public Task<List<RoleResponce>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
