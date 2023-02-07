namespace ProductTracking.Core.Entities.TrackingAggregate;
public class Item : BaseEntity
{
    public Guid ItemGroupId { get; set; }
    public ItemGroup ItemGroup { get; set; }
    public string Name { get; set; }
    public string NameShort { get; set; }

}
