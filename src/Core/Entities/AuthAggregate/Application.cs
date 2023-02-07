using ProductTracking.Core.Entities.Settings;

namespace ProductTracking.Core.Entities.AuthAggregate;
public class Application
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public string? Type { get; set; }

    public List<Office>? office { get; set; }

    public List<Module>? Modules { get; set; }
    public Application(string id, string name, string desc)
    {
        Id = Guid.Parse(id);
        Name = name;
        Desc = desc;
    }
    public Application() { }
}
