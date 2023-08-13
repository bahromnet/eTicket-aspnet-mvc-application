using Application.eTicket.MVC.UseCases.Permissions.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Permissions.Queries;
public record GetAllPermissionsQuery : IRequest<List<PermissionResponce>>;

public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, List<PermissionResponce>>
{
    public Task<List<PermissionResponce>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
