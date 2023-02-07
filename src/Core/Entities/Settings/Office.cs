using System.ComponentModel.DataAnnotations.Schema;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Enums.Settings;

namespace ProductTracking.Core.Entities.Settings;
public class Office : BaseEntity
{
    public string NameEng { get; set; }
    public string NameNep { get; set; }
    public string NameShort { get; set; }
    public string Code { get; set; }
    public bool? isParrent { get; set; } = false;
    public Guid? ParentId { get; set; }
    public Office? Parent { get; set; }
    public List<Office>? Children { get; set; }
    public List<Application>? Applications { get; set; }
    public List<Role>? Roles { get; set; }

    public List<User>? Users { get; set; }
    public EnOfficeType officeType { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public string? Website { get; set; }
    public string? Logo { get; set; }
    [ForeignKey("EntryBy")]
    public Guid? EntryById { get; set; }
    public User? EntryBy { get; set; }

    public Office(string id, string nameEng, string code, string address, string contacts, DateTime entrydate, string? nameNep = null, string? nameShort = null)
    {
        Id = Guid.Parse(id);
        NameEng = nameEng;
        NameNep = nameNep ?? nameEng;
        Code = code;
        NameShort = nameShort ?? code;
        Address = address;
        Contact = contacts;
        EntryDate = entrydate;
        UpdatedDate = null;
    }
    public Office()
    {
    }

}
