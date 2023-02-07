using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Api.DTO.ProductTracking;
using ProductTracking.Core.DTO;
using ProductTracking.Core.Interfaces.CommonInterfaces;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;

namespace ProductTracking.Api.Controllers.CommonController;
[Route("api/[controller]")]
[ApiController]
public class ExcellExportController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IContainerService _containerService;
    private readonly IExcellExportService _excellExportService;
    public ExcellExportController(IMapper mapper, IContainerService containerService, IExcellExportService excellExportService)
    {
        _mapper = mapper;
        _containerService = containerService;
        _excellExportService = excellExportService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CreateExcelSheet(Guid id)
    {
        try
        {
            var container = await _containerService.GetByIdAsync(id);
            var content = await _excellExportService.GetExcellAsync(_mapper.Map<ContainerExcellDTO>(container));
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ContainerInfo.xlsx");

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


}
