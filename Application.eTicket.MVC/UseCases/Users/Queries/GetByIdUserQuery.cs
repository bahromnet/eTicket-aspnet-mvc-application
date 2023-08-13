using Application.eTicket.MVC.UseCases.Users.Responce;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Users.Queries;
public record GetByIdUserQuery : IRequest<UserResponce>
{
    public Ulid Id { get; }
}

public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserResponce>
{
    public Task<UserResponce> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
