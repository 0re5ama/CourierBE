using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Api.DTO.Security;
using ProductTracking.Api.DTO.Settings;
using ProductTracking.Core.Interfaces.Security;
using ProductTracking.Core.Interfaces.Settings;

namespace ProductTracking.Api.Controllers.Security;
[Route("api/security/[controller]")]
[ApiController]
[Authorize]
public class OfficeController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IUserService _userService;
    private readonly IOfficeService _officeService;
    public OfficeController(IMapper Mapper, IUserService userService, IOfficeService officeService)
    {
        _mapper = Mapper;
        _userService = userService;
        _officeService = officeService;

    }
    [HttpGet]
    public async Task<Response<List<OfficeListDTO>>> GetOfficeName()
    {
        var listOrg = await _officeService.GetAsync();
        return new Response<List<OfficeListDTO>>(_mapper.Map<List<OfficeListDTO>>(listOrg));
    }



    [HttpGet("officeUser/{id}")]
    public async Task<Response<List<UserResponseDTO>>> GetOrganizationUser(Guid id)
    {
        var organizationUser = await _userService.GetOfficeUserAsync(id);

        return new Response<List<UserResponseDTO>>(_mapper.Map<List<UserResponseDTO>>(organizationUser));
    }
}
