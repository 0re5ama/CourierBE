using ProductTracking.Core.Enums;

namespace ProductTracking.Api.DTO.ProductTracking;

public class HeaderContactDetailRequestDTO
{
    public string Desc { get; set; }
    public string ConatactNo { get; set; }
    public int OrderSNo { get; set; }
    public string Location { get; set; }
    public EnStatus Status { get; set; }
}
