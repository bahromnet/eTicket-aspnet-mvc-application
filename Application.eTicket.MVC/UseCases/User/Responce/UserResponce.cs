namespace Application.eTicket.MVC.UseCases.User.Responce;
public class UserResponce
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string? Picture { get; set; }
    public List<string>? Roles { get; set; }
}
