using System;
using eWarranty.DependencyServices;
using eWarranty.Models;
using Xamarin.Forms;

namespace eWarranty.Controls
{
    public class Overlay
    {
		public Overlay()
		{
			OverlayService = DependencyService.Get<IOverlayService>();
		}

		private IOverlayService OverlayService { get; }

		public void Show(View onView, ShowCaseConfig config)
		{
			OverlayService.AddOverlay(onView, config);
		}

		public void Hide()
		{
			OverlayService.HideOverlay();
		}
	}
}
