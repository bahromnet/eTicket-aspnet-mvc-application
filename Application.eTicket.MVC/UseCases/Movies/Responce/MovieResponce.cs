using Domain.eTicket.MVC.Enums;

namespace Application.eTicket.MVC.UseCases.Movies.Responce;
public class MovieResponce
{
    public Ulid Id { get; set; }
    public string MovieName { get; set; }
    public string MovieDescription { get; set; }
    public decimal MoviePrice { get; set; }
    public string MovieImage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public MovieCategory MovieCategory { get; set; }
    public int ProducerId { get; set; }
}
