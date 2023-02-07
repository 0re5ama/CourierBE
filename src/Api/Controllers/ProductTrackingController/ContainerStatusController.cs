using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Api.Controllers.ProductTrackingController;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContainerStatusController : ControllerBase
{
    #region getContainerStatus
    [HttpGet]
    public async Task<Response<List<EnDropdownDTO>>> GetEnums()
    {
        var list = Enum.GetValues(typeof(EnContainerStatus))
            .Cast<EnContainerStatus>()
            .Select(x => new EnDropdownDTO() { Id = (int)x, Name = x.ToString() }).ToList();
        return new Response<List<EnDropdownDTO>>(list);
    }
    #endregion
}
