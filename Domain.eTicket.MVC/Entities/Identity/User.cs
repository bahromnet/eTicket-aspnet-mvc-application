using Domain.eTicket.MVC.Commons;

namespace Domain.eTicket.MVC.Entities.Identity;
public class User : BaseAuditableEntity
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Role>? Roles { get; set; }
}
