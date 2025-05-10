using System;
using AndroidX.AppCompat.Widget;
//using Android.Support.V7.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace eWarranty.Droid.Renderers
{
    internal class MyShellToolbarAppearanceTracker : IShellToolbarAppearanceTracker
    {
        private MyShellRenderer myShellRenderer;
        public static AndroidX.AppCompat.Widget.Toolbar Mytoolbar;
        public MyShellToolbarAppearanceTracker(MyShellRenderer myShellRenderer)
        {

            this.myShellRenderer = myShellRenderer;
        }

        //public void Dispose()
        //{
        //    //throw new System.NotImplementedException();
        //}

        //public void ResetAppearance(Toolbar toolbar, IShellToolbarTracker toolbarTracker)
        //{
        //    // throw new System.NotImplementedException();
        //}

        //public void SetAppearance(Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
        //{
        //    //throw new System.NotImplementedException();

        //    Mytoolbar = toolbar;


        //}

        //public void SetAppearance(Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
        //{
        //    throw new NotImplementedException();
        //}

        //public void ResetAppearance(Toolbar toolbar, IShellToolbarTracker toolbarTracker)
        //{
        //    throw new NotImplementedException();
        //}
        public void Dispose()
        {
           // throw new NotImplementedException();
        }

        public void ResetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker)
        {
           // throw new NotImplementedException();
        }

        public void SetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
        {
            Mytoolbar = toolbar;
        }
    }
}
