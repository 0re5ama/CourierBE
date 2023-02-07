using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Api.DTO.ProductTracking;
using ProductTracking.Api.DTO.Security;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;

namespace ProductTracking.Api.Controllers.ProductTrackingController;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CheckpointController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICheckpointService _checkpointService;
    public CheckpointController(IMapper mapper, ICheckpointService checkpointService)
    {
        _mapper = mapper;
        _checkpointService = checkpointService;
    }
    #region getCheckpoints
    [HttpGet]
    public async Task<Response<List<CheckpointListDTO>>> GetCheckpoints()
    {
        var checkpointrepo = await _checkpointService.GetAsync();
        return new Response<List<CheckpointListDTO>>(_mapper.Map<List<CheckpointListDTO>>(checkpointrepo));
    }
    #endregion


    #region saveCheckpoint
    [Authorize]
    [HttpPost]
    public async Task<Response<CheckpointRequestDTO>> SaveCheckpoint(CheckpointRequestDTO checkpointDTO)
    {
        var savecheckpoint = await _checkpointService.SaveAsync(_mapper.Map<Checkpoint>(checkpointDTO));
        return new Response<CheckpointRequestDTO>(_mapper.Map<CheckpointRequestDTO>(savecheckpoint),true,"Checkpoint Successfully Created");
    }
    #endregion

    #region updateCheckpoint
    [Authorize]
    [HttpPut("{id}")]
    public async Task<Response<CheckpointRequestDTO>> UpdateCheckpoint(Guid id, CheckpointRequestDTO checkpoint)
    {
        var recpt = _mapper.Map<Checkpoint>(checkpoint);
        recpt.Id = id;
        var updatecheckpoint = await _checkpointService.UpdateAsync(id, recpt);
        return new Response<CheckpointRequestDTO>(_mapper.Map<CheckpointRequestDTO>(updatecheckpoint),true,"Checkpoint Successfully Updated");
    }
    #endregion

    #region getCheckpointDetails

    [HttpGet("{id}")]
    public async Task<Response<CheckpointResponseDTO>> GetCheckpoint(Guid id)
    {
        var checkpointrepo = await _checkpointService.GetByIdAsync(id);
        return new Response<CheckpointResponseDTO>(_mapper.Map<CheckpointResponseDTO>(checkpointrepo));
    }
    #endregion

    #region deleteCheckpoint
    [HttpDelete("{id}")]
    public async Task<Response<CheckpointResponseDTO>> DeleteCheckpoint(Guid id)
    {
        var checkpointrepo = await _checkpointService.DeleteAsync(id);
        return new Response<CheckpointResponseDTO>(_mapper.Map<CheckpointResponseDTO>(checkpointrepo),true,"Checkpoint Deleted Suceessfully");
    }
    #endregion

    [HttpGet("checkpointlessUser")]
    public async Task<Response<List<UserResponseDTO>>> GetCheckpointlessUser()
    {
        var checkpointrepo = await _checkpointService.GetCheckpointLessAsync();
        return new Response<List<UserResponseDTO>>(_mapper.Map<List<UserResponseDTO>>(checkpointrepo));
    }
}
