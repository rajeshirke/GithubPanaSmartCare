using System;
using eWarranty.Models;
using Xamarin.Forms;

namespace eWarranty.DependencyServices
{
    public interface IOverlayService
    {
        void AddOverlay(View onView, ShowCaseConfig config);
        void HideOverlay();
    }
}
