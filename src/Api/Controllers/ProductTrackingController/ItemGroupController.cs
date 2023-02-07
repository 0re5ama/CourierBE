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
public class ItemGroupController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IItemGroupService _ItemGroupService;
    public ItemGroupController(IMapper mapper, IItemGroupService ItemGroupService)
    {
        _mapper = mapper;
        _ItemGroupService = ItemGroupService;
    }
    #region getItemGroups
    [HttpGet]
    public async Task<Response<List<ItemGroupListDTO>>> GetItemGroups()
    {
        var ItemGrouprepo = await _ItemGroupService.GetAsync();
        return new Response<List<ItemGroupListDTO>>(_mapper.Map<List<ItemGroupListDTO>>(ItemGrouprepo));
    }
    #endregion


    #region saveItemGroup
    [Authorize]
    [HttpPost]
    public async Task<Response<ItemGroupRequestDTO>> SaveItemGroup(ItemGroupRequestDTO ItemGroupDTO)
    {
        var saveItemGroup = await _ItemGroupService.SaveAsync(_mapper.Map<ItemGroup>(ItemGroupDTO));
        return new Response<ItemGroupRequestDTO>(_mapper.Map<ItemGroupRequestDTO>(saveItemGroup), true, "successfully saved items group");
    }
    #endregion

    #region updateItemGroup
    [Authorize]
    [HttpPut("{id}")]
    public async Task<Response<ItemGroupResponseDTO>> UpdateItemGroup(Guid id, ItemGroupResponseDTO ItemGroup)
    {
        var recpt = _mapper.Map<ItemGroup>(ItemGroup);
        recpt.Id = id;
        var updateItemGroup = await _ItemGroupService.UpdateAsync(id, recpt);
        return new Response<ItemGroupResponseDTO>(_mapper.Map<ItemGroupResponseDTO>(updateItemGroup),true,"Item Group Successfully Updated");
    }
    #endregion

    #region getItemGroupDetails

    [HttpGet("{id}")]
    public async Task<Response<ItemGroupResponseDTO>> GetItemGroup(Guid id)
    {
        var ItemGrouprepo = await _ItemGroupService.GetByIdAsync(id);
        return new Response<ItemGroupResponseDTO>(_mapper.Map<ItemGroupResponseDTO>(ItemGrouprepo));
    }
    #endregion

    #region deleteItemGroup
    [HttpDelete("{id}")]
    public async Task<Response<ItemGroupResponseDTO>> DeleteItemGroup(Guid id)
    {
        var ItemGrouprepo = await _ItemGroupService.DeleteAsync(id);
        return new Response<ItemGroupResponseDTO>(_mapper.Map<ItemGroupResponseDTO>(ItemGrouprepo),true,"Item Group Sucessfully Deleted");
    }
    #endregion
}
