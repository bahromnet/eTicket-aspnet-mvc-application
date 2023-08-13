using Application.eTicket.MVC.UseCases.Permissions.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Permissions.Queries;
public record GetByIdPermissionQuery : IRequest<PermissionResponce>
{
    public Ulid Id { get; }
}

public class GetByIdPermissionQueryHandler : IRequestHandler<GetByIdPermissionQuery, PermissionResponce>
{
    public Task<PermissionResponce> Handle(GetByIdPermissionQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
