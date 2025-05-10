using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWarranty.Views.Customer.DashBoardView
{
    public class EWMasterDetailPageMenuItem
    {
        public EWMasterDetailPageMenuItem()
        {
            TargetType = typeof(EWMasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
