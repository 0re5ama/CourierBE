using Microsoft.AspNetCore.Identity;
using ProductTracking.Core.Entities.Settings;
using ProductTracking.Core.Enums;
using ProductTracking.Core.Interfaces;

namespace ProductTracking.Core.Entities.AuthAggregate;

public class Role : IdentityRole<Guid>, IAggregateRoot
{
    public string Desc { get; set; }
    public EnStatus Status { get; set; }
    public string EntryBy { get; set; } = "";
    public DateTime EntryDate { get; set; } = DateTime.UtcNow;
    public DateTime FromDate { get; set; } = DateTime.UtcNow;
    public DateTime? ToDate { get; set; }
    public List<User>? Users { get; set; } = new List<User>();
    public List<RoleModuleFunction> RoleModuleFunctions { get; set; }
    public Guid OfficeId { get; set; } = Guid.Parse("187cda14-9844-42e7-99ba-b8d4f0d59c3a");
    public Office Office { get; set; }
    public List<Module>? Modules { get; set; }

    public Role(string name, string desc, string officeId)
    {
        Name = name;
        Desc = desc;
        OfficeId = Guid.Parse(officeId);
    }

    public Role()
    { }

}
