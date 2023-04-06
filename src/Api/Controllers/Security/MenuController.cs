using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProductTracking.Api.DTO;
using ProductTracking.Api.DTO.Security;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.Security;
using ProductTracking.Infrastructure.Data;

namespace ProductTracking.Api.Controllers.Security;

[Route("api/Security/[controller]")]
[ApiController]
[Authorize]
public class MenuController : ControllerBase
{
    private readonly IMenuService _service;
    private readonly IMapper _mapper;

    public MenuController(IMenuService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<Response<List<MenuResponseDTO>>> GetMenuByUserIdAsync()
    {
        var list = await _service.GetAsync();
        var res = _mapper.Map<List<MenuResponseDTO>>(list);
        return new Response<List<MenuResponseDTO>>(res);

    }
}
