using ProductTracking.Core.Entities.AuthAggregate;

namespace ProductTracking.Api.DTO;

public class UserInfo
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public Guid UserId { get; set; }
    public Guid? CheckpointId { get; set; }
    public UserInfo(User user)
    {
        Name = user.Name;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        UserId = user.Id;
        CheckpointId = user.CheckpointId;
    }
}
