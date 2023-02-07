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
public class ContainerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IContainerService _containerService;
    public ContainerController(IMapper mapper, IContainerService containerService)
    {
        _mapper = mapper;
        _containerService = containerService;
    }
    #region getContainers 
    [HttpGet]
    public async Task<Response<List<ContainerListDTO>>> GetContainers()
    {
        var containerrepo = await _containerService.GetAsync();
        return new Response<List<ContainerListDTO>>(_mapper.Map<List<ContainerListDTO>>(containerrepo));
    }
    #endregion


    #region saveContainer
    [Authorize]
    [HttpPost]
    public async Task<Response<ContainerRequestDTO>> SaveContainer(ContainerRequestDTO containerDTO)
    {
        var savecontainer = await _containerService.SaveAsync(_mapper.Map<Container>(containerDTO));
        return new Response<ContainerRequestDTO>(_mapper.Map<ContainerRequestDTO>(savecontainer),true,"Container Sucessfully Created");
    }
    #endregion

    #region updateContainer
    [Authorize]
    [HttpPut("{id}")]
    public async Task<Response<ContainerRequestDTO>> UpdateContainer(Guid id, ContainerRequestDTO container)
    {
        var recpt = _mapper.Map<Container>(container);
        recpt.Id = id;
        var updatecontainer = await _containerService.UpdateAsync(id, recpt);
        return new Response<ContainerRequestDTO>(_mapper.Map<ContainerRequestDTO>(updatecontainer),true,"Container Sucessfully Recieved");
    }
    #endregion

    #region getContainerDetails

    [HttpGet("{id}")]
    public async Task<Response<ContainerResponseDTO>> GetContainer(Guid id)
    {
        try
        {
            var containerrepo = await _containerService.GetByIdAsync(id);
            return new Response<ContainerResponseDTO>(_mapper.Map<ContainerResponseDTO>(containerrepo));
        }
        catch (Exception ex)
        {
            return new Response<ContainerResponseDTO>();
        }

    }
    #endregion

    #region deleteContainer
    [HttpDelete("{id}")]
    public async Task<Response<ContainerResponseDTO>> DeleteContainer(Guid id)
    {
        var containerrepo = await _containerService.DeleteAsync(id);
        return new Response<ContainerResponseDTO>(_mapper.Map<ContainerResponseDTO>(containerrepo),true,"Container Sucessfully Deleted");
    }
    #endregion

    [Authorize]
    [HttpPost("transfer-container")]
    public async Task<Response<ContainerRequestDTO>> transferContainer(ContainerRequestDTO containerDTO)
    {
        var savecontainer = await _containerService.SaveTransferAsync(_mapper.Map<Container>(containerDTO));
        return new Response<ContainerRequestDTO>(_mapper.Map<ContainerRequestDTO>(savecontainer),true,"Container Sucessfully Transferd");
    }

    #region checkpointContainer
    [HttpGet("checkpointContainer")]
    public async Task<Response<List<ContainerListDTO>>> GetCheckpointContainers()
    {
        var containerrepo = await _containerService.GetcheckpointContainerAsync();
        return new Response<List<ContainerListDTO>>(_mapper.Map<List<ContainerListDTO>>(containerrepo));
    }
    #endregion

}
