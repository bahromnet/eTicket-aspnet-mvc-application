namespace Domain.eTicket.MVC.Entities;

public class Actor
{
    public int ActorId { get; set; }
    public string ActorName { get; set; }
    public string ActorImage { get; set; }
    public string ActorBio { get; set; }

    public ICollection<Movie>? Movies { get; set; }

}
