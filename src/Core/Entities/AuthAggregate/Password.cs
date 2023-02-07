namespace ProductTracking.Core.Entities.AuthAggregate;

public class Password : BaseEntity
{

    public User user { get; set; }
    public string PasswordHash { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
