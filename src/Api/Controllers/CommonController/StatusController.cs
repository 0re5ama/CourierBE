using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Core.Enums;

namespace ProductTracking.Api.Controllers.CommonController;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class StatusController : ControllerBase
{
    #region getStatus
    [HttpGet]
    public async Task<Response<List<EnDropdownDTO>>> GetEnums()
    {
        var list = Enum.GetValues(typeof(EnStatus))
            .Cast<EnStatus>()
            .Select(x => new EnDropdownDTO() { Id = (int)x, Name = x.ToString() }).ToList();
        return new Response<List<EnDropdownDTO>>(list);
    }
    #endregion
}
