namespace ProductTracking.Core.Entities.AuthAggregate;

public class UserStatus : BaseEntity
{
    public User User { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public string Remarks { get; set; }
    public int AuthorizationNo { get; set; }
    public string AuthorizedBy { get; set; }
    public DateTime AuthorizationDate { get; set; }
}
