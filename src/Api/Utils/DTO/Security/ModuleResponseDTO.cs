using ProductTracking.Core.Enums.Security;

namespace ProductTracking.Api.DTO.Security;

public class ModuleResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    // TODO: add function list
    public List<ModuleFunctionResponseDTO>? Functions { get; set; }
}

public class ModuleFunctionResponseDTO
{
    public Guid Id { get; set; }
    public EnFunction FunctionId { get; set; }
    public string FunctionName => FunctionId.ToString();
}
