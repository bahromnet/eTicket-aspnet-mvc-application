namespace Domain.eTicket.MVC.Entities.Identity;
public class UserRefreshToken
{
    public Ulid Id { get; set; }
    public string RefreshToken { get; set; }
    public string Email { get; set; }
    public DateTime ExpiredTime { get; set; }
}
