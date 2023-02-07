using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Api.DTO.ProductTracking;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;

namespace ProductTracking.Api.Controllers.ProductTrackingController;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class HeaderContactDetailController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IHeaderContactDetailService _checkpointService;
    public HeaderContactDetailController(IMapper mapper, IHeaderContactDetailService checkpointService)
    {
        _mapper = mapper;
        _checkpointService = checkpointService;
    }
    #region getHeaderContactDetails
    [HttpGet]
    public async Task<Response<List<HeaderContactDetailListDTO>>> GetHeaderContactDetails()
    {
        var checkpointrepo = await _checkpointService.GetAsync();
        return new Response<List<HeaderContactDetailListDTO>>(_mapper.Map<List<HeaderContactDetailListDTO>>(checkpointrepo));
    }
    #endregion


    #region saveHeaderContactDetail
    [Authorize]
    [HttpPost]
    public async Task<Response<HeaderContactDetailRequestDTO>> SaveHeaderContactDetail(HeaderContactDetailRequestDTO checkpointDTO)
    {
        var savecheckpoint = await _checkpointService.SaveAsync(_mapper.Map<HeaderContactDetail>(checkpointDTO));
        return new Response<HeaderContactDetailRequestDTO>(_mapper.Map<HeaderContactDetailRequestDTO>(savecheckpoint));
    }
    #endregion

    #region updateHeaderContactDetail
    [Authorize]
    [HttpPut("{id}")]
    public async Task<Response<HeaderContactDetailResponseDTO>> UpdateHeaderContactDetail(Guid id, HeaderContactDetailResponseDTO checkpoint)
    {
        var recpt = _mapper.Map<HeaderContactDetail>(checkpoint);
        recpt.Id = id;
        var updatecheckpoint = await _checkpointService.UpdateAsync(id, recpt);
        return new Response<HeaderContactDetailResponseDTO>(_mapper.Map<HeaderContactDetailResponseDTO>(updatecheckpoint));
    }
    #endregion

    #region getHeaderContactDetailDetails

    [HttpGet("{id}")]
    public async Task<Response<HeaderContactDetailResponseDTO>> GetHeaderContactDetail(Guid id)
    {
        var checkpointrepo = await _checkpointService.GetByIdAsync(id);
        return new Response<HeaderContactDetailResponseDTO>(_mapper.Map<HeaderContactDetailResponseDTO>(checkpointrepo));
    }
    #endregion

    #region deleteHeaderContactDetail
    [HttpDelete("{id}")]
    public async Task<Response<HeaderContactDetailResponseDTO>> DeleteHeaderContactDetail(Guid id)
    {
        var checkpointrepo = await _checkpointService.DeleteAsync(id);
        return new Response<HeaderContactDetailResponseDTO>(_mapper.Map<HeaderContactDetailResponseDTO>(checkpointrepo));
    }
    #endregion
}
