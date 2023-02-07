using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Api.DTO.Security;
using ProductTracking.Core.Interfaces.Security;

namespace ProductTracking.Api.Controllers.Security;
[Route("api/security/[controller]")]
[ApiController]
[Authorize]
public class ModuleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IModuleService _moduleService;
    public ModuleController(IMapper mapper, IModuleService moduleService)
    {
        _mapper = mapper;
        _moduleService = moduleService;
    }

    [HttpGet]
    public async Task<Response<List<ModuleResponseDTO>>> Get() // TODO: Rename function
    {
        var list = await _moduleService.GetAsync();
        var resp = _mapper.Map<List<ModuleResponseDTO>>(list);
        return new Response<List<ModuleResponseDTO>>(resp);
    }

    [HttpGet("{id}")]
    public async Task<Response<List<ModuleResponseDTO>>> GetModule(Guid id)
    {
        var list = await _moduleService.GetAsync(id);
        var module = _mapper.Map<List<ModuleResponseDTO>>(list);
        return new Response<List<ModuleResponseDTO>>(module);
    }


}
