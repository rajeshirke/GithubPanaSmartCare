using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class MainMenu
    {
        public MainMenu()
        {
            SubMenus = new HashSet<SubMenu>();
        }

        public int MainMenuId { get; set; }
        public string MainMenuName { get; set; }
        public int? MenuOrder { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<SubMenu> SubMenus { get; set; }
    }
}
