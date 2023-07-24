using Domain.eTicket.MVC.Commons;

namespace Domain.eTicket.MVC.Entities;

public class Actor : BaseAuditableEntity
{
    public string ActorName { get; set; }
    public string ActorImage { get; set; }
    public string ActorBio { get; set; }

    public virtual ICollection<Movie>? Movies { get; set; }

}
