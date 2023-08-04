using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItem.Commands;
public record CreateOrderItemCommand : IRequest<Ulid>
{
    public Ulid OrderId { get; set; }
    public Ulid MovieId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime ScreeningTime { get; set; }
}
