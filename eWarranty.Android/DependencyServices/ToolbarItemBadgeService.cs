
using Android.Views;
using eWarranty.DependencyServices;
using eWarranty.Droid.DependencyServices;
using eWarranty.Droid.Renderers;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(ToolbarItemBadgeService))]
namespace eWarranty.Droid.DependencyServices
{
    public class ToolbarItemBadgeService : IToolbarItemBadgeService
    {
        public void SetBadge(Page page, ToolbarItem item, string value, Color backgroundColor, Color textColor)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (item.Text == "dashbord")
                {
                    var toolbar = CrossCurrentActivity.Current.Activity.FindViewById(Resource.Id.shellcontent_toolbar) as AndroidX.AppCompat.Widget.Toolbar;
                    if (toolbar == null)
                        toolbar = CrossCurrentActivity.Current.Activity.FindViewById(Resource.Id.main_toolbar) as AndroidX.AppCompat.Widget.Toolbar;

                    if (toolbar == null)
                        toolbar = MyShellToolbarAppearanceTracker.Mytoolbar != toolbar && MyShellToolbarAppearanceTracker.Mytoolbar.Id == toolbar.Id ?
                                    MyShellToolbarAppearanceTracker.Mytoolbar :
                                    toolbar;
                    // var tb = CrossCurrentActivity.Current.Activity.FindViewById(Resource.Id.toolbar);
                    // var toolbar = CrossCurrentActivity.Current.Activity.FindViewById(Resource.Id.toolbar) as Android.Support.V7.Widget.Toolbar;
                    //  var toolbar = CrossCurrentActivity.Current.Activity.FindViewById(Resource.Id.toolbar) as Android.Support.V7.Widget.Toolbar;

                    // var toolbar = MyShellToolbarAppearanceTracker.Mytoolbar;
                    if (toolbar != null)
                    {
                        if (!string.IsNullOrEmpty(value))
                        {

                            var idx = page.ToolbarItems.IndexOf(item);
                            if (toolbar.Menu.Size() > idx)
                            {
                                IMenuItem menuItem = toolbar.Menu.GetItem(idx);
                                string menutitle = menuItem.ToString();
                                if (menutitle == item.Text)
                                {
                                    BadgeDrawable.SetBadgeText(CrossCurrentActivity.Current.Activity, menuItem, value, backgroundColor.ToAndroid(), textColor.ToAndroid());
                                }
                            }
                        }
                    }
                }
            });
        }
    }
}