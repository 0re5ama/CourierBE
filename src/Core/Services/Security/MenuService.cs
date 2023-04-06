using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProductTracking.Core.DTO;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.Security;

namespace ProductTracking.Core.Services.Security;
public class MenuService : IMenuService
{
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _currentUserService;
    public MenuService(IUnitOfWork uow, ICurrentUserService currentUserService)
    {
        _uow = uow;
        _currentUserService = currentUserService;
    }

    public async Task<List<MenuDTO>> GetAsync()
    {
        /*
        var repo = _uow.Repository<Menu>();
        return repo.GetAll().ToList();
        */

        var sprocUserMenu = "cfn_get_user_menu";
        //Guid x = Guid.Parse("d62ef199-acc5-42e4-81b7-da29f88c712b");
        //var sqlParams = new List<SqlParameter>() { new SqlParameter("@p_user_id", _currentUserService.UserId) };
        var sqlParams = new List<SqlParameter>() { new SqlParameter("@p_user_id", _currentUserService.UserId) };


        // List<MenuApplication> objApplication = (await _unitOfWork.Repository<MenuApplication>().SqlQueryAsync(sprocUserApp, params)).ToList();

        try
        {
            List<MenuDTO> list = (await _uow.Repository<MenuDTO>().SqlQueryAsync(sprocUserMenu, sqlParams)).ToList();


            var res = GenMenu(list, null);

            return res;
        } catch (Exception ex)
        {
            throw ex;
        }
    }

    private List<MenuDTO> GenMenu(List<MenuDTO> list, Guid? parentId)
    {
        var filter = list.Where(x => x.ParentId == parentId).OrderBy(x => x.OrderNo);
        if (filter.Count() == 0) return filter.ToList();
        
        return filter.Select(x =>
        {
            x.Routes = GenMenu(list, x.Id);
            return x;
        }).ToList();
    }
}
