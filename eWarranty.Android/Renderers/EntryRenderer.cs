using System;
using Android.Content;
using Android.Graphics;
using eWarranty.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(Entry), typeof(TxtEntryRenderer))]
namespace eWarranty.Droid.Renderers
{
    public class TxtEntryRenderer: EntryRenderer
    {
        Entry element;
        public TxtEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (Entry)this.Element;

            //Control.Background.SetColorFilter(Android.Graphics.Color.White, PorterDuff.Mode.SrcAtop);
           // Control.SetBackgroundResource(Resource.Drawable.rounded_edittext);
           
        }
    }
}
