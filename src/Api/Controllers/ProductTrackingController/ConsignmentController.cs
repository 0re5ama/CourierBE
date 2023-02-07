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
public class ConsignmentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IConsignmentService _consignmentService;
    public ConsignmentController(IMapper mapper, IConsignmentService consignmentService)
    {
        _mapper = mapper;
        _consignmentService = consignmentService;
    }
    #region getConsignments
    [HttpGet]
    public async Task<Response<List<ConsignmentListDTO>>> GetConsignments()
    {
        var consignmentrepo = await _consignmentService.GetAsync();
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion


    #region saveConsignment
    [Authorize]
    [HttpPost]
    public async Task<Response<ConsignmentRequestDTO>> SaveConsignment(ConsignmentRequestDTO consignmentDTO)
    {
        var saveconsignment = await _consignmentService.SaveAsync(_mapper.Map<Consignment>(consignmentDTO));
        return new Response<ConsignmentRequestDTO>(_mapper.Map<ConsignmentRequestDTO>(saveconsignment),true,"Consignment Sucessfully Created");
    }
    #endregion

    #region updateConsignment
    [Authorize]
    [HttpPut("{id}")]
    public async Task<Response<ConsignmentRequestDTO>> UpdateConsignment(Guid id, ConsignmentRequestDTO consignment)
    {
        var recpt = _mapper.Map<Consignment>(consignment);
        recpt.Id = id;
        var updateconsignment = await _consignmentService.UpdateAsync(id, recpt);
        return new Response<ConsignmentRequestDTO>(_mapper.Map<ConsignmentRequestDTO>(updateconsignment),true,"Consignment Sucessfully Updated" );
    }
    #endregion

    #region getConsignmentDetails

    [HttpGet("{id}")]
    public async Task<Response<ConsignmentResponseDTO>> GetConsignment(Guid id)
    {
        var consignmentrepo = await _consignmentService.GetByIdAsync(id);
        return new Response<ConsignmentResponseDTO>(_mapper.Map<ConsignmentResponseDTO>(consignmentrepo));
    }
    #endregion

    #region deleteConsignment
    [HttpDelete("{id}")]
    public async Task<Response<ConsignmentResponseDTO>> DeleteConsignment(Guid id)
    {
        var consignmentrepo = await _consignmentService.DeleteAsync(id);
        return new Response<ConsignmentResponseDTO>(_mapper.Map<ConsignmentResponseDTO>(consignmentrepo),true,"Consignment Sucessfully Deleted");
    }
    #endregion

    #region getRecentConsignments
    [HttpGet("recent-consignments")]
    public async Task<Response<List<ConsignmentListDTO>>> GetRecentConsignments()
    {
        var consignmentrepo = await _consignmentService.GetRecentConsignmentAsync();
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion

    #region getReceivedConsignments
    [HttpGet("received-consignments")]
    public async Task<Response<List<ConsignmentListDTO>>> GetReceivedConsignments()
    {
        var consignmentrepo = await _consignmentService.GetReceivedConsignmentAsync();
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion
    #region getSentConsignments
    [HttpGet("sent-consignments")]
    public async Task<Response<List<ConsignmentListDTO>>> GetSentConsignments()
    {
        var consignmentrepo = await _consignmentService.GetSentConsignmentAsync();
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion
    #region getContainerConsignments
    [HttpGet("search-consignments/{id}")]
    public async Task<Response<List<SearchConsignmentResponseDTO>>> GetContainerConsignments(Guid id)
    {
        var consignmentrepo = await _consignmentService.GetContainerConsignmentAsync(id);
        return new Response<List<SearchConsignmentResponseDTO>>(_mapper.Map<List<SearchConsignmentResponseDTO>>(consignmentrepo));
    }
    #endregion

    #region getIncomingConsignments
    [HttpGet("incoming-consignments")]
    public async Task<Response<List<ConsignmentListDTO>>> GetIncomingConsignments()
    {
        var consignmentrepo = await _consignmentService.GetIncomingConsignmentAsync();
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion


    #region getoutgoingConsignments
    [HttpGet("outgoing-consignments")]
    public async Task<Response<List<ConsignmentListDTO>>> GetoutgoingConsignments()
    {
        var consignmentrepo = await _consignmentService.GetOutgoingConsignmentAsync();
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion

    #region getpaidConsignments
    [HttpGet("paid-consignments")]
    public async Task<Response<List<ConsignmentListDTO>>> GetpaidConsignments()
    {
        var consignmentrepo = await _consignmentService.GetPaidConsignmentAsync();
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion


    #region getpaidConsignments
    [HttpGet("consignmentsAtCheckpoints")]
    public async Task<Response<List<ConsignmentListDTO>>> GetConsignmentAtCheckpoints()
    {
        var consignmentrepo = await _consignmentService.GetConsignmentAtCheckpointsAsync();
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion

    #region getFilterConsignments
    [HttpGet("filterConsignments/{time}")]
    public async Task<Response<List<ConsignmentListDTO>>> GetFilterConsignments(int time)
    {
        var consignmentrepo = await _consignmentService.GetFilterConsignmentsAsync(time);
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion
    #region getFilterConsignments
    [HttpGet("suggestConsignments/{param}")]
    public async Task<Response<List<ConsignmentListDTO>>> GetSuggestConsignments(string param)
    {
        var consignmentrepo = await _consignmentService.GetSuggestConsignmentsAsync(param);
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion

    #region getCheckpointConsignments
    [HttpGet("checkpointConsignments")]
    public async Task<Response<List<ConsignmentListDTO>>> GetCheckpointConsignments()
    {
        var consignmentrepo = await _consignmentService.GetCheckpointConsignmentsAsync();
        return new Response<List<ConsignmentListDTO>>(_mapper.Map<List<ConsignmentListDTO>>(consignmentrepo));
    }
    #endregion





}
