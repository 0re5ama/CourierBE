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
public class ItemController : ControllerBase
{

    private readonly IMapper _mapper;
    private readonly IItemService _itemService;
    public ItemController(IMapper mapper, IItemService itemService)
    {
        _mapper = mapper;
        _itemService = itemService;
    }
    #region getItems
    [HttpGet]
    public async Task<Response<List<ItemListDTO>>> GetItems()
    {
        var itemrepo = await _itemService.GetAsync();
        return new Response<List<ItemListDTO>>(_mapper.Map<List<ItemListDTO>>(itemrepo));
    }
    #endregion


    #region saveItem
    [Authorize]
    [HttpPost]
    public async Task<Response<ItemRequestDTO>> SaveItem(ItemRequestDTO itemDTO)
    {
        var saveitem = await _itemService.SaveAsync(_mapper.Map<Item>(itemDTO));
        return new Response<ItemRequestDTO>(_mapper.Map<ItemRequestDTO>(saveitem),true,"Item Sucessfully Saved");
    }
    #endregion

    #region updateItem
    [Authorize]
    [HttpPut("{id}")]
    public async Task<Response<ItemResponseDTO>> UpdateItem(Guid id, ItemResponseDTO item)
    {
        var recpt = _mapper.Map<Item>(item);
        recpt.Id = id;
        var updateitem = await _itemService.UpdateAsync(id, recpt);
        return new Response<ItemResponseDTO>(_mapper.Map<ItemResponseDTO>(updateitem),true,"Item Sucessfully Updated");
    }
    #endregion

    #region getItemDetails

    [HttpGet("{id}")]
    public async Task<Response<ItemResponseDTO>> GetItem(Guid id)
    {
        var itemrepo = await _itemService.GetByIdAsync(id);
        return new Response<ItemResponseDTO>(_mapper.Map<ItemResponseDTO>(itemrepo));
    }
    #endregion

    #region deleteItem
    [HttpDelete("{id}")]
    public async Task<Response<ItemResponseDTO>> DeleteItem(Guid id)
    {
        var itemrepo = await _itemService.DeleteAsync(id);
        return new Response<ItemResponseDTO>(_mapper.Map<ItemResponseDTO>(itemrepo),true,"Item Sucessfully Deleted");
    }
    #endregion

    #region getGroupsItems

    [HttpGet("groups-item/{id}")]
    public async Task<Response<List<ItemListDTO>>> GetgroupItem(Guid id)
    {
        var itemrepo = await _itemService.GetByItemGroupAsync(id);
        return new Response<List<ItemListDTO>>(_mapper.Map<List<ItemListDTO>>(itemrepo));
    }
    #endregion

}
