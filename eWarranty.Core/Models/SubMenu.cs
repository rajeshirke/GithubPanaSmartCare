﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class SubMenu
    {
        public int SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int? MainMenuId { get; set; }
        public int? PersonRoleId { get; set; }
        public int? SubMenuOrder { get; set; }

        public virtual MainMenu MainMenu { get; set; }
        public virtual PersonRole PersonRole { get; set; }
    }
}
