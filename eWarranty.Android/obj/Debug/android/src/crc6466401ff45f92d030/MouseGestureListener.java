package crc6466401ff45f92d030;


public class MouseGestureListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MR.Gestures.Android.MouseGestureListener, MR.Gestures", MouseGestureListener.class, __md_methods);
	}


	public MouseGestureListener ()
	{
		super ();
		if (getClass () == MouseGestureListener.class) {
			mono.android.TypeManager.Activate ("MR.Gestures.Android.MouseGestureListener, MR.Gestures", "", this, new java.lang.Object[] {  });
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
