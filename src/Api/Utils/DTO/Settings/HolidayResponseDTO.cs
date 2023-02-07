namespace ProductTracking.Api.DTO.Settings;

public class HolidayResponseDTO
{
    public Guid Id { get; set; }
    public int year { get; set; }
    public int Month { get; set; }
    public List<DayDTO> Days { get; set; }
}
