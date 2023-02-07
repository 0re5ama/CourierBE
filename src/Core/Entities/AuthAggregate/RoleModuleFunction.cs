namespace ProductTracking.Core.Entities.AuthAggregate;
public class RoleModuleFunction
{
    public Guid? RoleId { get; set; }
    public Role Role { get; set; }
    //public Guid? ModuleId { get; set; }
    //public Module Module { get; set; }

    public Guid? ModuleFunctionId { get; set; }
    public ModuleFunction ModuleFunction { get; set; }
    //public Guid? ApplicationId { get; set; }

    //public Application Application { get; set; }
    //public string FunCd { get; set; }


}
