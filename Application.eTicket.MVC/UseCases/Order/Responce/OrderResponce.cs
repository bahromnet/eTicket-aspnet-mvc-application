namespace Application.eTicket.MVC.UseCases.Order.Responce;
public class OrderResponce
{
    public Ulid Id { get; set; }
    public Ulid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }
}
