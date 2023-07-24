using Domain.eTicket.MVC.Commons;

namespace Domain.eTicket.MVC.Entities.Identity;
public class Permission : BaseAuditableEntity
{
    public string Name { get; set; }
    public virtual ICollection<Role>? Roles { get; set; }
}
