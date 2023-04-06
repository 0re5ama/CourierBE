using System.ComponentModel.DataAnnotations.Schema;

namespace ProductTracking.Core.DTO;
public class MenuDTO
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string? Path { get; set; }
    public string? Component { get; set; }
    public int? OrderNo { get; set; }

    [NotMapped]
    public List<MenuDTO>? Routes { get; set; }
}
