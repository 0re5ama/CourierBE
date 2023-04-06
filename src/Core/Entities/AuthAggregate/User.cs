using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ProductTracking.Core.Entities.Settings;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Enums;
using ProductTracking.Core.Interfaces;

namespace ProductTracking.Core.Entities.AuthAggregate;

public class User : IdentityUser<Guid>, IAggregateRoot
{
    public Guid EmployeeId { get; set; }
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public string? Contact { get; set; }
    [NotMapped]
    public string? Password { get; set; }
    public int? AuthorizationNo { get; set; }
    public string? AuthorizedBy { get; set; }
    public DateTime? AuthorizationDate { get; set; }
    public bool HasPasswordChanged { get; set; } = false;
    public string? PasswordResetToken { get; set; }
    public string? EntryBy { get; set; }
    public DateTime EntryDate { get; set; } = DateTime.UtcNow;
    public EnStatus Status { get; set; }
    public Guid? CheckpointId { get; set; }
    public Checkpoint? Checkpoint { get; set; }
    public bool IsSuperAdmin { get; set; }
    public List<UserModuleFunction> UserModuleFunctions { get; set; }
    public Guid OfficeId { get; set; } = Guid.Parse("187cda14-9844-42e7-99ba-b8d4f0d59c3a");
    public Office Office { get; set; }
    public List<Role>? Roles { get; set; }

    public User(string id, string userName, string email, string name, string officeId,DateTime entryDate)
    {
        Id = Guid.Parse(id);
        UserName = userName;
        Name = name;
        Email = email;
        OfficeId = Guid.Parse(officeId);
        EntryDate = entryDate;
    }

    public User(string userName, string name, string email)
    {
        UserName = userName;
        Name = name;
        Email = email;
    }

    public User()
    { }
}
