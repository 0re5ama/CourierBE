using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Api.DTO.Settings;
using ProductTracking.Core.Entities.Settings;
using ProductTracking.Core.Interfaces.Settings;

namespace ProductTracking.Api.Controllers.Settings;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OfficeController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IOfficeService _officeService;
    public OfficeController(IMapper Mapper, IOfficeService officeService)
    {
        _mapper = Mapper;
        _officeService = officeService;
    }
    [HttpGet]
    public async Task<Response<List<OfficeListDTO>>> GetOffices()
    {
        var offices = await _officeService.GetAsync();
        return new Response<List<OfficeListDTO>>(_mapper.Map<List<OfficeListDTO>>(offices));
    }

    [HttpGet("{id}")]
    public async Task<Response<OfficeResponseDTO>> GetOffice(Guid id)
    {
        var Office = await _officeService.GetByIdAsync(id);
        return new Response<OfficeResponseDTO>(_mapper.Map<OfficeResponseDTO>(Office));
    }

    [HttpPost]
    public async Task<Response<OfficeRequestDTO>> SaveOffice(OfficeRequestDTO office)
    {
        var savedOffice = await _officeService.SaveAsync(_mapper.Map<Office>(office));
        return new Response<OfficeRequestDTO>(_mapper.Map<OfficeRequestDTO>(savedOffice));
    }

    [HttpPut("{id}")]
    public async Task<Response<OfficeRequestDTO>> UpdateOffice(Guid id, OfficeRequestDTO office)
    {
        var updateOffice = await _officeService.UpdateAsync(id, _mapper.Map<Office>(UpdateOffice));
        return new Response<OfficeRequestDTO>(_mapper.Map<OfficeRequestDTO>(updateOffice));
    }

    [HttpDelete("{id}")]
    public async Task<Response<OfficeResponseDTO>> DeleteOffice(Guid id)
    {
        var deleteOffice = await _officeService.DeleteAsync(id);
        return new Response<OfficeResponseDTO>(_mapper.Map<OfficeResponseDTO>(deleteOffice));
    }
}
