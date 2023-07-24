using Domain.eTicket.MVC.Commons;
using Domain.eTicket.MVC.Entities.Identity;

namespace Domain.eTicket.MVC.Entities;

public class Order : BaseAuditableEntity
{
    public Ulid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }

}
