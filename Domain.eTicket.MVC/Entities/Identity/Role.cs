using Domain.eTicket.MVC.Commons;

namespace Domain.eTicket.MVC.Entities.Identity;
public class Role : BaseAuditableEntity
{
    public string Name { get; set; }
    public virtual ICollection<Permission> Permissions { get; set; }
    public virtual ICollection<User>? Users { get; set; }
}
