using Domain.eTicket.MVC.Commons;

namespace Domain.eTicket.MVC.Entities;

public class Producer : BaseAuditableEntity
{
    public string ProducerName { get; set; }
    public string ProducerImage { get; set; }
    public string ProducerBio { get; set; }

    public virtual List<Movie>? Movies { get; set; }
}
