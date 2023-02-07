using ProductTracking.Core.Enums.Settings;

namespace ProductTracking.Api.DTO.Settings;

public class OfficeRequestDTO
{
    public string NameEng { get; set; }
    public string NameNep { get; set; }
    public string NameShort { get; set; }
    public bool? isParrent { get; set; } = false;
    public string? ParentName { get; set; }
    public EnOfficeType officeType { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public string? Website { get; set; }
    public string? Logo { get; set; }
}
