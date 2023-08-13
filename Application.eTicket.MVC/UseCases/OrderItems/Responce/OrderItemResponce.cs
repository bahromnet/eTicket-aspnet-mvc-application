namespace Application.eTicket.MVC.UseCases.OrderItems.Responce;
public class OrderItemResponce
{
    public Ulid Id { get; set; }
    public Ulid OrderId { get; set; }
    public Ulid MovieId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime ScreeningTime { get; set; }
}
