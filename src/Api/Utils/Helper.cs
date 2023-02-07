namespace ProductTracking.Api.Utils;

public class Helper
{
    public static string GetStatusText(string status)
    {
        switch (status)
        {
            case "A":
                return "Active";
            case "I":
                return "Inactive";
            case "D":
                return "Disabled";
            default:
                return "Invalid";
        }
    }
}
