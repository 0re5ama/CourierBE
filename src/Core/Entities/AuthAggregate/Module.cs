namespace ProductTracking.Core.Entities.AuthAggregate;

public class Module
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public Guid ApplicationId { get; set; } = Guid.Parse("541f2c3a-c67e-4b70-b58d-188486b7e04a");
    public Application Application { get; set; }
    public List<ModuleFunction>? Functions { get; set; }
    public Guid? MenuId { get; set; }
    public Menu? Menu { get; set; }
    public List<Role>? Roles { get; set; }

    public Module(string id, string applicationId, string name, string description, DateTime fromDate, string menuId)
    {
        Id = Guid.Parse(id);
        Name = name;
        Description = description;
        FromDate = fromDate;
        ToDate = null;
        ApplicationId = Guid.Parse(applicationId);
        MenuId = Guid.Parse(menuId);
    }

    public Module()
    {
    }
}
