using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.eTicket.MVC.UseCases.Users.Commands.CreateUser;
public record CreateUserCommand : IRequest<Ulid>
{
    public Ulid Id { get; }
    public string FullName { get; }
    public string UserName { get; }
    public string Phone { get; }
    public string Email { get; }
    public IFormFile? Picture { get; }
    public List<string>? Roles { get; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Ulid>
{
    public Task<Ulid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
