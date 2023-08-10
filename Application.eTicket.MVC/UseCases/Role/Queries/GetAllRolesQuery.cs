using Application.eTicket.MVC.UseCases.Role.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Role.Queries;
public record GetAllRolesQuery : IRequest<List<RoleResponce>>;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleResponce>>
{
    public Task<List<RoleResponce>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
