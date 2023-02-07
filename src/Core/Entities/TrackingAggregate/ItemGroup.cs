namespace ProductTracking.Core.Entities.TrackingAggregate;
public class ItemGroup : BaseEntity
{
    public string Name { get; set; }
    public List<Item>? Items { get; set; }
}
