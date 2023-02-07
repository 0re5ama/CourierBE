using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProductTracking.Api.DTO.Security;
using ProductTracking.Core.Interfaces;
using ProductTracking.Infrastructure.Data;

namespace ProductTracking.Api.Controllers.Security;

[Route("api/Security/[controller]")]
[ApiController]
[Authorize]
public class MenuController : ControllerBase
{
    private readonly ProductTrackingDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;

    public MenuController(ProductTrackingDbContext context, IConfiguration configuration, ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
    {
        _context = context;
        _configuration = configuration;
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<List<MenuResponseDTO>> GetMenuByUserIdAsync()
    {
        var sprocUserApp = "dbo.cfn_get_user_applications";
        var sprocUserMenu = "dbo.cfn_get_user_menu";
        //Guid x = Guid.Parse("d62ef199-acc5-42e4-81b7-da29f88c712b");
        //var sqlParams = new List<SqlParameter>() { new SqlParameter("@p_user_id", _currentUserService.UserId) };
        var sqlParamsUserApp = new List<SqlParameter>() { new SqlParameter("@p_user_id", _currentUserService.UserId) };
        var sqlParamsUserMenu = new List<SqlParameter>() { new SqlParameter("@p_user_id", _currentUserService.UserId) };


        List<MenuApplication> objApplication = (await _unitOfWork.Repository<MenuApplication>().SqlQueryAsync(sprocUserApp, sqlParamsUserApp)).ToList();

        List<MenuDTO> objMenu = (await _unitOfWork.Repository<MenuDTO>().SqlQueryAsync(sprocUserMenu, sqlParamsUserMenu)).ToList();

        List<MenuResponseDTO> ret = new List<MenuResponseDTO>();

        if (objApplication.Count > 0 && objMenu.Count > 0)
        {
            foreach (var objA in objApplication)
            {
                MenuResponseDTO menuResponseDTO = new MenuResponseDTO();
                menuResponseDTO.Name = objA.Name;
                //menuResponseDTO.Icon = "form";

                List<MenuRouteResponseDTO> menuRouteResponseDTO = new List<MenuRouteResponseDTO>();
                foreach (var objM in objMenu)
                {
                    if (objM.ApplicationId == objA.Id)
                    {
                        MenuRouteResponseDTO data = new MenuRouteResponseDTO();
                        data.Name = objM.MenuText;
                        data.Icon = objM.Icon;
                        data.Path = objM.MUrl;
                        data.Component = string.Concat(".", objM.MUrl);
                        menuRouteResponseDTO.Add(data);
                    }
                }
                menuResponseDTO.Routes = menuRouteResponseDTO;
                ret.Add(menuResponseDTO); //menuResponseDTO.Routes;
            }
        }
        //ret.Clear();
        return ret;
    }
}
