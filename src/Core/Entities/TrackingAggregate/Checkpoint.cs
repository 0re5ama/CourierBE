using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Entities.AuthAggregate;

namespace ProductTracking.Core.Entities.TrackingAggregate;
public class Checkpoint:BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Consignment>? Consignments { get; set; }
    public List<User> Users { get; set; }

}
