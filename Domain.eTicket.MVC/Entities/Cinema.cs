using Domain.eTicket.MVC.Commons;

namespace Domain.eTicket.MVC.Entities;

public class Cinema : BaseAuditableEntity
{
    public string CinemaName { get; set; }
    public string CinemaDescription { get; set; }
    public string CinemaLogo { get; set; }
    public string CinemaLocation { get; set; }

    public ICollection<Movie>? Movies { get; set; }
}
