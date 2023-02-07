using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Api.Controllers.CommonController;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PaymentStatusController : ControllerBase
{
    #region getPaymentStatus
    [HttpGet]
    public async Task<Response<List<EnDropdownDTO>>> GetEnums()
    {
        var list = Enum.GetValues(typeof(EnPaymentStatus))
            .Cast<EnPaymentStatus>()
            .Select(x => new EnDropdownDTO() { Id = (int)x, Name = x.ToString() }).ToList();
        return new Response<List<EnDropdownDTO>>(list);
    }
    #endregion
}
