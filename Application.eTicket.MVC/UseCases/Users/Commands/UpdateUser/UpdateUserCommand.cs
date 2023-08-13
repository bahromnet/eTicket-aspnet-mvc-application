using MediatR;

namespace Application.eTicket.MVC.UseCases.Users.Commands.UpdateUser;
public record UpdateUserCommand : IRequest
{
    public Ulid Id { get; }
    public string FullName { get; }
    public string UserName { get; }
    public string Phone { get; }
    public string Email { get; }
    public string? Picture { get; }
    public List<string>? Roles { get; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
