using System;
using Xamarin.Forms;

namespace eWarranty.DependencyServices
{
    public interface IToolbarItemBadgeService
    {
        void SetBadge(Page page, ToolbarItem item, string value, Color backgroundColor, Color textColor);
    }
}
