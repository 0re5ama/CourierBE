using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Core.Enums.Settings;

namespace ProductTracking.Api.Controllers.Settings;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OfficeTypeController : ControllerBase
{
    #region getAddressType
    [HttpGet]
    public async Task<Response<List<EnDropdownDTO>>> GetEnums()
    {
        var list = Enum.GetValues(typeof(EnOfficeType))
            .Cast<EnOfficeType>()
            .Select(x => new EnDropdownDTO() { Id = (int)x, Name = x.ToString() }).ToList();
        return new Response<List<EnDropdownDTO>>(list);
    }
    #endregion

}
