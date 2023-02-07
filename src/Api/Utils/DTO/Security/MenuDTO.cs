namespace ProductTracking.Api.DTO.Security; 

public class MenuDTO
{
    public MenuDTO()
    {
    }

    public MenuDTO(Guid id, Guid applicationId, string menuText, string mUrl, Guid parentId, string icon)
    {
        Id = id;
        ApplicationId = applicationId;
        MenuText = menuText;
        MUrl = mUrl;
        ParentId = parentId;
        Icon = icon;
    }

    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public string MenuText { get; set; }
    public string MUrl { get; set; }
    public Guid? ParentId { get; set; }
    public string Icon { get; set; }
}
