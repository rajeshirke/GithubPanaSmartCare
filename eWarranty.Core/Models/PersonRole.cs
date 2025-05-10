using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PersonRole
    {
        public PersonRole()
        {
            Persons = new HashSet<Person>();
            SubMenus = new HashSet<SubMenu>();
        }

        public int PersonRoleId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ChatbotEnquiry> ChatbotEnquiries { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<SubMenu> SubMenus { get; set; }
    }
}
