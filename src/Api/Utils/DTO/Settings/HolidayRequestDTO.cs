namespace ProductTracking.Api.DTO.Settings;

public class HolidayRequestDTO
{
    public string year { get; set; }
    public string Month { get; set; }
    public List<DayRequestDTO> Days { get; set; }
}

public class DayRequestDTO
{
    public int day { get; set; }
    public string remarks { get; set; }
}
