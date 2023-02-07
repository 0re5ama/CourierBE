namespace ProductTracking.Api.DTO.Security;

public class OrganizationListDTO
{
    public Guid Id { get; set; }
    public string NameEng { get; set; }
    public UserResponseDTO User { get; set; }

}
