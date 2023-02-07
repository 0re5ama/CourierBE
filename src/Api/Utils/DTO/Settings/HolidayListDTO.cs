namespace ProductTracking.Api.DTO.Settings;

public class HolidayListDTO
{
    public int year { get; set; }
    public int Month { get; set; }
    public List<DayDTO> Days { get; set; }
}

public class DayDTO
{
    public Guid Id { get; set; }

    public int day { get; set; }
    public string remarks { get; set; }
}
