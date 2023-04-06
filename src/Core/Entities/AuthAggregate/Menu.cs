using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

    public Menu(
        string id, 
        string menuText, 
        string toolTip, 
        string? usedIn, 
        int orderNo, 
        string? mUrl, 
        string parentId,
        // char hasChild,
        bool secApl, 
        string? icon, 
        bool active = true
    )
    {
        Id = Guid.Parse(id);
        MenuText = menuText;
        ToolTip = toolTip;
        UsedIn = usedIn;
        OrderNo = orderNo;
        MUrl = mUrl;
        ParentId = string.IsNullOrEmpty(parentId) == true ? null : Guid.Parse(parentId);
        // HasChild = hasChild;
        SecApl = secApl;
        Icon = icon;
        Active = active;
    }

    public Guid Id { get; set; }
    public string MenuText { get; set; }
    public string ToolTip { get; set; }
    public string? UsedIn { get; set; }
    public int OrderNo { get; set; }
    public string? MUrl { get; set; }
    public Guid? ParentId { get; set; }
    public Menu? Parent { get; set; }
    // public char HasChild { get; set; }
    public bool SecApl { get; set; }
    public string? Icon { get; set; }
    public bool Active { get; set; } = true;
    [NotMapped]
    public List<Menu>? Children { get; set; } 
}
