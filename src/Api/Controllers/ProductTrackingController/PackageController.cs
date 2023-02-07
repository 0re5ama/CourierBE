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
public class PackageController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPackageService _packageService;
    public PackageController(IMapper mapper, IPackageService packageService)
    {
        _mapper = mapper;
        _packageService = packageService;
    }
    #region getPackages
    [HttpGet]
    public async Task<Response<List<PackageListDTO>>> GetPackages()
    {
        var packagerepo = await _packageService.GetAsync();
        return new Response<List<PackageListDTO>>(_mapper.Map<List<PackageListDTO>>(packagerepo));
    }
    #endregion


    #region savePackage
    [Authorize]
    [HttpPost]
    public async Task<Response<PackageRequestDTO>> SavePackage(PackageRequestDTO packageDTO)
    {
        var savepackage = await _packageService.SaveAsync(_mapper.Map<Package>(packageDTO));
        return new Response<PackageRequestDTO>(_mapper.Map<PackageRequestDTO>(savepackage),true,"Package Sucessfuly Saved");
    }
    #endregion

    #region updatePackage
    [Authorize]
    [HttpPut("{id}")]
    public async Task<Response<PackageRequestDTO>> UpdatePackage(Guid id, PackageRequestDTO package)
    {
        var recpt = _mapper.Map<Package>(package);
        recpt.Id = id;
        var updatepackage = await _packageService.UpdateAsync(id, recpt);
        return new Response<PackageRequestDTO>(_mapper.Map<PackageRequestDTO>(updatepackage),true,"Package Sucessfully Deleted");
    }
    #endregion

    #region getPackageDetails

    [HttpGet("{id}")]
    public async Task<Response<PackageResponseDTO>> GetPackage(Guid id)
    {
        var packagerepo = await _packageService.GetByIdAsync(id);
        return new Response<PackageResponseDTO>(_mapper.Map<PackageResponseDTO>(packagerepo));
    }
    #endregion

    #region deletePackage
    [HttpDelete("{id}")]
    public async Task<Response<PackageResponseDTO>> DeletePackage(Guid id)
    {
        var packagerepo = await _packageService.DeleteAsync(id);
        return new Response<PackageResponseDTO>(_mapper.Map<PackageResponseDTO>(packagerepo),true,"Package Delete Sucessfully");
    }
    #endregion
}

