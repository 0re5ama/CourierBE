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
public class ApplicationController : ControllerBase
{
    private readonly IModuleService _moduleService;
    private readonly IMapper _mapper;
    public ApplicationController(IModuleService moduleService, IMapper mapper)
    {
        _moduleService = moduleService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<Response<List<ApplicationResponseDTO>>> GetAsync()
    {
        var list = await _moduleService.GetApplicationsAsync();
        return new Response<List<ApplicationResponseDTO>>(_mapper.Map<List<ApplicationResponseDTO>>(list));
    }

    [HttpGet("appwithmod")]
    public async Task<Response<List<ApplicationResponseDTO>>> GetApplicationsWithModulesAsync()
    {
        var list = await _moduleService.GetApplicationsWithModulesAsync();
        return new Response<List<ApplicationResponseDTO>>(_mapper.Map<List<ApplicationResponseDTO>>(list));
    }

}
