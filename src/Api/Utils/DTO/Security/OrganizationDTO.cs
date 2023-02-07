namespace ProductTracking.Api.DTO.Security;

public class OrganizationDTO
{
    public Guid id { get; set; }

    public string nameEng { get; set; }

    public string code { get; set; }

    public List<UserResponseDTO> Users { get; set; }
}
