namespace ProductTracking.Core.Entities.AuthAggregate;
public class UserModuleFunction
{
    public Guid? UserId { get; set; }
    public User User { get; set; }
    public Guid? ModuleFunctionId { get; set; }
    public ModuleFunction ModuleFunction { get; set; }
}
