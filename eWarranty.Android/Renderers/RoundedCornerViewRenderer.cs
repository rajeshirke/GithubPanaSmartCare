using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using eWarranty.Controls;
using eWarranty.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(RoundedCornerView), typeof(RoundedCornerViewRenderer))]

namespace eWarranty.Droid.Renderers
{
    [Obsolete]
    public class RoundedCornerViewRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
          //  SetOutlineSpotShadowColor(Xamarin.Forms.Color.HotPink.ToAndroid());
        }
        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        {
            if (Element == null) return false;
            RoundedCornerView rcv = (RoundedCornerView)Element;
            this.SetClipChildren(true);
            rcv.Padding = new Thickness(0, 0, 0, 0);
            //rcv.HasShadow = false;      
            int radius = (int)(rcv.RoundedCornerRadius);
            // Check if make circle is set to true. If so, then we just use the width and      
            // height of the control to calculate the radius. RoundedCornerRadius will be ignored      
            // in this case.      
            if (rcv.MakeCircle)
            {
                radius = Math.Min(Width, Height) / 2;
            }
            // When we create a round rect, we will have to double the radius since it is not      
            // the same as creating a circle.      
            radius *= 2;
            try
            {
                //Create path to clip the child       
                var path = new Path();
                path.AddRoundRect(new RectF(0, 0, Width, Height), new float[] {
                    radius,
                    radius,
                    radius,
                    radius,
                    radius,
                    radius,
                    radius,
                    radius
                }, Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);
                // Draw the child first so that the border shows up above it.      
                var result = base.DrawChild(canvas, child, drawingTime);
                canvas.Restore();
                /*   
                 * If a border is specified, we use the same path created above to stroke   
                 * with the border color.   
                 * */
                if (rcv.BorderWidth > 0)
                {
                    // Draw a filled circle.      
                    var paint = new Paint();
                    paint.AntiAlias = true;
                    paint.StrokeWidth = rcv.BorderWidth;
                    paint.SetStyle(Paint.Style.Stroke);
                    paint.Color = rcv.BorderColor.ToAndroid();

                    canvas.DrawPath(path, paint);

                    paint.Dispose();
                }
                if (rcv.Shadow)
                {
                    this.SetBackgroundResource(Resource.Drawable.FrameRenderValue);
                  //  Control.Elevation = 2;
                    GradientDrawable drawable = (GradientDrawable)this.Background;
                    drawable.SetColor(Android.Graphics.Color.ParseColor("#f5f5f5"));
                }
                //Properly dispose      
                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            return base.DrawChild(canvas, child, drawingTime);
        }
        //public override void Draw(Canvas canvas)
        //{
        //    base.Draw(canvas);

        //    DrawOutline(canvas, canvas.Width, canvas.Height, 5f);//set corner radius
        //}
        //void DrawOutline(Canvas canvas, int width, int height, float cornerRadius)
        //{

        //    RoundedCornerView rcv = (RoundedCornerView)Element;

        //    using (var paint = new Paint { AntiAlias = true })
        //    using (var path = new Path())
        //    using (Path.Direction direction = Path.Direction.Cw)
        //    using (Paint.Style style = Paint.Style.Stroke)
        //    using (var rect = new RectF(0, 0, width, height))
        //    {
        //        float rx = Forms.Context.ToPixels(rcv.RoundedCornerRadius);
        //        float ry = Forms.Context.ToPixels(rcv.RoundedCornerRadius);
        //        path.AddRoundRect(rect, rx, ry, direction);

        //        canvas.Save();
        //        canvas.ClipPath(path);

        //        //
        //        //paint.set(Paint.Style.Fill);
        //       // paint.StrokeWidth = rcv.BorderWidth;
        //        paint.SetStyle(Paint.Style.Stroke);
        //        paint.Color = rcv.FillColor.ToAndroid();
        //        paint.SetStyle(Paint.Style.Fill);
        //       // paint.Alpha = 1;
        //        canvas.DrawPath(path, paint);
        //        //canvas.DrawColor(Android.Graphics.Color.ParseColor(rcv.FillColor.ToHex()));
        //        // paint.StrokeWidth = 5f;  //set outline stroke
        //        // paint.SetStyle(style);
        //        //canvas.DrawColor(Android.Graphics.Color.ParseColor(rcv.FillColor.ToHex()));
        //        // paint.Color =  Android.Graphics.Color.ParseColor(rcv.FillColor.ToHex());//set outline color //_frame.OutlineColor.ToAndroid(); 
        //        //canvas.DrawColor(Android.Graphics.Color.ParseColor(rcv.FillColor.ToHex()));
        //        //canvas.DrawPath(path, paint);

        //    }
        //}
    }
}
