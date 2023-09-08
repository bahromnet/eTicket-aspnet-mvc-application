using Domain.eTicket.MVC.Commons;

namespace Domain.eTicket.MVC.Entities;

public class Order : BaseAuditableEntity
{
    public Ulid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; } = false;
    public virtual ICollection<OrderItem> OrderItems { get; set; }

}
