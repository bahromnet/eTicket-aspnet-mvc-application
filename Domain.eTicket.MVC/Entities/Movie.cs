using Domain.eTicket.MVC.Commons;
using Domain.eTicket.MVC.Enums;

namespace Domain.eTicket.MVC.Entities;

public class Movie : BaseAuditableEntity
{
    public string MovieName { get; set; }
    public string MovieDescription { get; set; }
    public decimal MoviePrice { get; set; }
    public string MovieImage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public MovieCategory MovieCategory { get; set; }

    public int ProducerId { get; set; }
    public virtual Producer Producer { get; set; }  

    public virtual ICollection<Actor>? Actors { get; set; } 

}
