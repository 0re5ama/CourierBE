using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Core.Entities.TrackingAggregate;
public class ContainerConsignment : BaseEntity
{
    public Guid? ContainerId { get; set; }
    public Container? Container { get; set; }
    public Guid? ConsignmentId { get; set; }
    public Consignment? Consignment { get; set; }
    public string? Remarks { get; set; }
    public EnRecivedStatus? RecivedStatus { get; set; }
    public DateTime? RecivedDate { get; set; } 
}
