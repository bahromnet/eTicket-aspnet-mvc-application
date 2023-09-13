namespace Application.eTicket.MVC.UseCases.Orders.Responce;
public class MovieOrder
{
    public Ulid MovieId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime ScreeningTime { get; set; }
}
