namespace Domain.eTicket.MVC.Entities;

public class OrderItem
{
    public Ulid OrderId { get; set; }
    public Ulid MovieId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime ScreeningTime { get; set; } 

    public virtual Order Order { get; set; }
}
