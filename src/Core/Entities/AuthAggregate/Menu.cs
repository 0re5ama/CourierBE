using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.IdentityModel.Tokens;

namespace ProductTracking.Core.Entities.AuthAggregate;

public class Menu
{
    public Menu()
    {
    }

    public Menu(string id, string menuText, string toolTip, string? usedIn, int orderNo, string? mUrl, string parentId, char hasChild, char secApl, string icon)
    {
        Id = Guid.Parse(id);
        MenuText = menuText;
        ToolTip = toolTip;
        UsedIn = usedIn;
        OrderNo = orderNo;
        MUrl = mUrl;
        ParentId = string.IsNullOrEmpty(parentId) == true ? null : Guid.Parse(parentId);
        HasChild = hasChild;
        SecApl = secApl;
        Icon = icon;
    }

    public Guid Id { get; set; }
    public string MenuText { get; set; }
    public string ToolTip { get; set; }
    public string? UsedIn { get; set; }
    public int OrderNo { get; set; }
    public string? MUrl { get; set; }
    public Guid? ParentId { get; set; }
    public char HasChild { get; set; }
    public char SecApl { get; set; }
    public string Icon { get; set; }
}
