using ProductTracking.Core.Enums.Settings;

namespace ProductTracking.Api.DTO.Settings;

public class OfficeResponseDTO
{
    public Guid Id { get; set; }
    public string nameEng { get; set; }
    public string nameNep { get; set; }
    public string shortName { get; set; }
    public bool? isParrent { get; set; } = false;
    public string? parentName { get; set; }
    public EnOfficeType officeType { get; set; }
    public string address { get; set; }
    public string contact { get; set; }
    public string? website { get; set; }
    public string? logo { get; set; }
}
