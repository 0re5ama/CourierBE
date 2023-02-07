using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.DTO;
using ProductTracking.Core.Entities.TrackingAggregate;

namespace ProductTracking.Core.Interfaces.CommonInterfaces;
public interface IExcellExportService
{
    Task<byte[]> GetExcellAsync(ContainerExcellDTO container);

}
