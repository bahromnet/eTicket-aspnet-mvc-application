using Domain.eTicket.MVC.Entities.Identity;

namespace Application.eTicket.MVC.UseCases.Roles.Responce;
public class RoleResponce
{
    public Ulid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Permission>? Permissions { get; set; }
}
