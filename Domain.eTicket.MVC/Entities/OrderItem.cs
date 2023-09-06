using Domain.eTicket.MVC.Commons;

namespace Domain.eTicket.MVC.Entities;

public class OrderItem : BaseAuditableEntity
{
    public Ulid OrderId { get; set; }
    public Ulid MovieId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime ScreeningTime { get; set; }

    public virtual Order Order { get; set; }
    public virtual Movie Movie { get; set; }
}
