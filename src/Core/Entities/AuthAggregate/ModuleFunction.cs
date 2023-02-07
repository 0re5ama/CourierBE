using ProductTracking.Core.Enums.Security;

namespace ProductTracking.Core.Entities.AuthAggregate;
public class ModuleFunction
{
    public Guid Id { get; set; }
    public Guid ModuleId { get; set; }
    public Module Module { get; set; }
    public EnFunction FunctionId { get; set; }
    public List<Role>? Roles { get; set; }
    public ModuleFunction(string id, string moduleId, EnFunction functionId)
    {
        Id = Guid.Parse(id);
        ModuleId = Guid.Parse(moduleId);
        FunctionId = functionId;
    }
    public ModuleFunction()
    {
    }
}
