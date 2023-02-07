using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracking.Core.Entities.TrackingAggregate;
public class ConsignmentItem:BaseEntity
{
    public Guid? ConsignmentId { get; set; }
    public Consignment? Consignment { get; set; }
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
    public int Quantity { get; set; }
    public string? Photo { get; set; }
    public string? Remarks { get; set; }
}
