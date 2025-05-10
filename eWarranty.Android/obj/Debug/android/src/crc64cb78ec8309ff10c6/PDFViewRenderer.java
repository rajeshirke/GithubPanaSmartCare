package crc64cb78ec8309ff10c6;


public class PDFViewRenderer
	extends crc643f46942d9dd1fff9.WebViewRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("eWarranty.Droid.Renderers.PDFViewRenderer, eWarranty.Android", PDFViewRenderer.class, __md_methods);
	}


	public PDFViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == PDFViewRenderer.class) {
			mono.android.TypeManager.Activate ("eWarranty.Droid.Renderers.PDFViewRenderer, eWarranty.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public PDFViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == PDFViewRenderer.class) {
			mono.android.TypeManager.Activate ("eWarranty.Droid.Renderers.PDFViewRenderer, eWarranty.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public PDFViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == PDFViewRenderer.class) {
			mono.android.TypeManager.Activate ("eWarranty.Droid.Renderers.PDFViewRenderer, eWarranty.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
