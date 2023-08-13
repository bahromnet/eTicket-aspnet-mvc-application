using Application.eTicket.MVC.UseCases.Users.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Users.Queries;
public record GetAllUsersQuery : IRequest<List<UserResponce>>;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserResponce>>
{
    public Task<List<UserResponce>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
