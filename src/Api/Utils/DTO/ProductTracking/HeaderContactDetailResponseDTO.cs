using ProductTracking.Core.Enums;

namespace ProductTracking.Api.DTO.ProductTracking;

public class HeaderContactDetailResponseDTO
{
    public Guid Id { get; set; }
    public string Desc { get; set; }
    public string ConatactNo { get; set; }
    public int OrderSNo { get; set; }
    public string Location { get; set; }
    public EnStatus Status { get; set; }
}
