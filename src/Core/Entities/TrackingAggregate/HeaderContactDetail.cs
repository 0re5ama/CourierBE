namespace ProductTracking.Core.Entities.TrackingAggregate;
public class HeaderContactDetail : BaseEntity
{
    public string Desc { get; set; }
    public string ConatactNo { get; set; }
    public int OrderSNo { get; set; }
    public string Location { get; set; }
}
