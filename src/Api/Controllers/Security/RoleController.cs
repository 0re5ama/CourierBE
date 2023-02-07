using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Api.DTO.Security;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Interfaces.Security;

namespace ProductTracking.Api.Controllers.Security;
[Route("api/security/[controller]")]
[ApiController]
[Authorize]
public class RoleController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IRoleService _roleService;
    public RoleController(IMapper mapper, IRoleService roleService)
    {
        _mapper = mapper;
        _roleService = roleService;
    }
    [HttpGet]
    public async Task<Response<List<RoleListDTO>>> GetRoles()
    {
        var list = await _roleService.GetAsync();
        return new Response<List<RoleListDTO>>(_mapper.Map<List<RoleListDTO>>(list));
    }
    [HttpGet("{id}")]
    public async Task<Response<RoleResponseDTO>> GetRole(Guid id)
    {

        var role = await _roleService.GetAsync(id);
        return new Response<RoleResponseDTO>(_mapper.Map<RoleResponseDTO>(role));
    }
    [HttpPost]
    /// <summary>
    /// Save Role
    /// </summary>
    /// <param name="role"></param>
    /// <returns>Saved Role</returns>
    public async Task<Response<RoleRequestDTO>> SaveRole(RoleRequestDTO role)
    {
        var savedRole = await _roleService.SaveAsync(_mapper.Map<Role>(role));
        return new Response<RoleRequestDTO>(_mapper.Map<RoleRequestDTO>(savedRole), message: "Role Successfully Saved!");

    }
    [HttpPut("{id}")]
    public async Task<Response<RoleRequestDTO>> UpdateRole(Guid id, RoleRequestDTO role)
    {
        var Role = _mapper.Map<Role>(role);
        Role.Id = id;
        var updaterole = await _roleService.UpdateAsync(id, Role);
        return new Response<RoleRequestDTO>(_mapper.Map<RoleRequestDTO>(updaterole),true,"Role Successfully Updated");
    }

    [HttpDelete("{id}")]

    public async Task<Response<RoleListDTO>> DeleteRole(Guid id)
    {
        var deleterole = await _roleService.DeleteAsync(id);
        return new Response<RoleListDTO>(_mapper.Map<RoleListDTO>(deleterole),true,"Role Successfully Deleted");
    }
}
