namespace ProductTracking.Core.Entities.AuthAggregate;
public class LoginLog
{
    public Guid Id { get; set; }
    public User? User { get; set; }
    public string? UserName { get; set; }
    public string IpAddress { get; set; }
    public string ClientAgent { get; set; }
    public string? OS { get; set; }
    public DateTime LoginDate { get; set; } = DateTime.Now;
}
