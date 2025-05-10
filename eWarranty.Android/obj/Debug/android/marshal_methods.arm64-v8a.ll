; ModuleID = 'obj/Debug/android/marshal_methods.arm64-v8a.ll'
source_filename = "obj/Debug/android/marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [516 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 158
	i64 30579257353033782, ; 1: Syncfusion.Buttons.XForms => 0x6ca3ac2c05d836 => 59
	i64 36418902923615093, ; 2: Plugin.LocalNotification => 0x8162cc9bdf1b75 => 49
	i64 45886493525149769, ; 3: Xamarin.Forms.Material => 0xa30585d28e0849 => 215
	i64 98382396393917666, ; 4: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 41
	i64 120698629574877762, ; 5: Mono.Android => 0x1accec39cafe242 => 42
	i64 196720943101637631, ; 6: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 251
	i64 210515253464952879, ; 7: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 146
	i64 229321459903363178, ; 8: Syncfusion.Cards.XForms => 0x32eb6a71ce9f86a => 61
	i64 232391251801502327, ; 9: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 190
	i64 233177144301842968, ; 10: Xamarin.AndroidX.Collection.Jvm.dll => 0x33c696097d9f218 => 147
	i64 263803244706540312, ; 11: Rg.Plugins.Popup.dll => 0x3a937a743542b18 => 52
	i64 295915112840604065, ; 12: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 191
	i64 316157742385208084, ; 13: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 152
	i64 347331204332682223, ; 14: ImageCircle.Forms.Plugin => 0x4d1f7e3dda87bef => 25
	i64 464346026994987652, ; 15: System.Reactive.dll => 0x671b04057e67284 => 97
	i64 533980546060132701, ; 16: Microsoft.AppCenter.Analytics.dll => 0x769147a3ce2215d => 30
	i64 590536689428908136, ; 17: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x83201fd803ec868 => 109
	i64 634308326490598313, ; 18: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 171
	i64 687654259221141486, ; 19: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 223
	i64 702024105029695270, ; 20: System.Drawing.Common => 0x9be17343c0e7726 => 12
	i64 720058930071658100, ; 21: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 163
	i64 761608270782653079, ; 22: Syncfusion.SfBusyIndicator.XForms.Android => 0xa91c6afe5ffe297 => 72
	i64 774222078205450857, ; 23: Syncfusion.SfListView.XForms.Android => 0xabe96e0ccb35a69 => 80
	i64 799765834175365804, ; 24: System.ComponentModel.dll => 0xb1956c9f18442ac => 13
	i64 816102801403336439, ; 25: Xamarin.Android.Support.Collections => 0xb53612c89d8d6f7 => 113
	i64 822256607215579516, ; 26: Microsoft.AppCenter.Analytics.Android.Bindings.dll => 0xb693e071b4d717c => 29
	i64 846634227898301275, ; 27: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0xbbfd9583890bb5b => 106
	i64 872800313462103108, ; 28: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 157
	i64 940822596282819491, ; 29: System.Transactions => 0xd0e792aa81923a3 => 242
	i64 996343623809489702, ; 30: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 218
	i64 1000557547492888992, ; 31: Mono.Security.dll => 0xde2b1c9cba651a0 => 256
	i64 1119473885309432845, ; 32: Shiny.Core.dll => 0xf892b914531f40d => 53
	i64 1120440138749646132, ; 33: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 220
	i64 1202444765235964449, ; 34: Syncfusion.Expander.XForms.dll => 0x10aff124a5eaea21 => 66
	i64 1212813105769650772, ; 35: Syncfusion.DataSource.Portable => 0x10d4c7180c569a54 => 64
	i64 1315114680217950157, ; 36: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 141
	i64 1342439039765371018, ; 37: Xamarin.Android.Support.Fragment => 0x12a14d31b1d4d88a => 122
	i64 1425944114962822056, ; 38: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 18
	i64 1435064484980070193, ; 39: Syncfusion.SfComboBox.XForms.dll => 0x13ea5f8bb9041731 => 79
	i64 1451832606041849089, ; 40: SignaturePad.Forms.dll => 0x1425f21024743d01 => 56
	i64 1490981186906623721, ; 41: Xamarin.Android.Support.VersionedParcelable => 0x14b1077d6c5c0ee9 => 133
	i64 1491290866305144020, ; 42: Xamarin.Google.AutoValue.Annotations.dll => 0x14b2212446e714d4 => 221
	i64 1576750169145655260, ; 43: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x15e1bdecc376bfdc => 204
	i64 1624659445732251991, ; 44: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 139
	i64 1628611045998245443, ; 45: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 174
	i64 1636321030536304333, ; 46: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 164
	i64 1731380447121279447, ; 47: Newtonsoft.Json => 0x18071957e9b889d7 => 45
	i64 1743969030606105336, ; 48: System.Memory.dll => 0x1833d297e88f2af8 => 248
	i64 1744702963312407042, ; 49: Xamarin.Android.Support.v7.AppCompat => 0x18366e19eeceb202 => 131
	i64 1785689246005058196, ; 50: Xamanimation => 0x18c80ae8835dda94 => 102
	i64 1795316252682057001, ; 51: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 140
	i64 1826484464927925024, ; 52: Xamarin.AndroidX.Room.Room.Ktx => 0x1958f9f197cc6320 => 188
	i64 1836611346387731153, ; 53: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 190
	i64 1875917498431009007, ; 54: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 136
	i64 1938067011858688285, ; 55: Xamarin.Android.Support.v4.dll => 0x1ae565add0bd691d => 130
	i64 1981742497975770890, ; 56: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 173
	i64 2040001226662520565, ; 57: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 257
	i64 2064708342624596306, ; 58: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x1ca7514c5eecb152 => 230
	i64 2076847052340733488, ; 59: Syncfusion.Core.XForms => 0x1cd27163f7962630 => 63
	i64 2126915263223078201, ; 60: Syncfusion.GridCommon.Portable => 0x1d845229bbc49d39 => 67
	i64 2133195048986300728, ; 61: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 45
	i64 2136356949452311481, ; 62: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 178
	i64 2141054624086497428, ; 63: Syncfusion.SfCarousel.XForms.Android => 0x1db68dd639621894 => 74
	i64 2165725771938924357, ; 64: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 144
	i64 2197658138908603915, ; 65: Microsoft.AppCenter.Android.Bindings.dll => 0x1e7fa66f0364b60b => 31
	i64 2203565783020068373, ; 66: Xamarin.KotlinX.Coroutines.Core => 0x1e94a367981dde15 => 233
	i64 2254786158495914142, ; 67: Syncfusion.SfProgressBar.XForms.Android.dll => 0x1f4a9c10959dd89e => 85
	i64 2262844636196693701, ; 68: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 157
	i64 2284400282711631002, ; 69: System.Web.Services => 0x1fb3d1f42fd4249a => 243
	i64 2287834202362508563, ; 70: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 16
	i64 2304837677853103545, ; 71: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0x1ffc6da80d5ed5b9 => 186
	i64 2329709569556905518, ; 72: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 167
	i64 2337758774805907496, ; 73: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 98
	i64 2469392061734276978, ; 74: Syncfusion.Core.XForms.Android.dll => 0x22450aff2ad74f72 => 62
	i64 2470498323731680442, ; 75: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 151
	i64 2479423007379663237, ; 76: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 198
	i64 2497223385847772520, ; 77: System.Runtime => 0x22a7eb7046413568 => 99
	i64 2541787113603107559, ; 78: Lottie.Android.dll => 0x23463de9b0fa8ae7 => 27
	i64 2547086958574651984, ; 79: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 135
	i64 2592350477072141967, ; 80: System.Xml.dll => 0x23f9e10627330e8f => 100
	i64 2624866290265602282, ; 81: mscorlib.dll => 0x246d65fbde2db8ea => 44
	i64 2656907746661064104, ; 82: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 37
	i64 2694427813909235223, ; 83: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 182
	i64 2713070138985274548, ; 84: Syncfusion.SfListView.XForms.Android.dll => 0x25a6c2eabcefdcb4 => 80
	i64 2749910993029543237, ; 85: Microsoft.AppCenter.Crashes => 0x2629a57a7f77b545 => 33
	i64 2783046991838674048, ; 86: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 98
	i64 2787234703088983483, ; 87: Xamarin.AndroidX.Startup.StartupRuntime => 0x26ae3f31ef429dbb => 194
	i64 2801558180824670388, ; 88: Plugin.CurrentActivity.dll => 0x26e1225279a4e0b4 => 46
	i64 2949706848458024531, ; 89: Xamarin.Android.Support.SlidingPaneLayout => 0x28ef76c01de0a653 => 128
	i64 2960931600190307745, ; 90: Xamarin.Forms.Core => 0x2917579a49927da1 => 212
	i64 2977248461349026546, ; 91: Xamarin.Android.Support.DrawerLayout => 0x29514fb392c97af2 => 121
	i64 3017704767998173186, ; 92: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 220
	i64 3022227708164871115, ; 93: Xamarin.Android.Support.Media.Compat.dll => 0x29f11c168f8293cb => 126
	i64 3171992396844006720, ; 94: Square.OkIO => 0x2c052e476c207d40 => 57
	i64 3217286949467762653, ; 95: Syncfusion.SfChart.XForms.Android.dll => 0x2ca6196f4386afdd => 76
	i64 3260998928894807349, ; 96: Lottie.Forms.dll => 0x2d41653f91b44d35 => 28
	i64 3289520064315143713, ; 97: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 166
	i64 3303437397778967116, ; 98: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 137
	i64 3308638413622236918, ; 99: Shiny.Core => 0x2deaa51b762a56f6 => 53
	i64 3311221304742556517, ; 100: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 96
	i64 3339480741387858005, ; 101: Xamarin.AndroidX.Work.Runtime => 0x2e58380a7cae7055 => 205
	i64 3344514922410554693, ; 102: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 234
	i64 3364695309916733813, ; 103: Xamarin.Firebase.Common => 0x2eb1cc8eb5028175 => 207
	i64 3411255996856937470, ; 104: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 224
	i64 3493805808809882663, ; 105: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 196
	i64 3522470458906976663, ; 106: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 195
	i64 3530710316062465247, ; 107: Plugin.Multilingual => 0x30ff9a5371b5dcdf => 51
	i64 3531994851595924923, ; 108: System.Numerics => 0x31042a9aade235bb => 95
	i64 3571415421602489686, ; 109: System.Runtime.dll => 0x319037675df7e556 => 99
	i64 3609787854626478660, ; 110: Plugin.CurrentActivity => 0x32188aeda587da44 => 46
	i64 3710460007389013999, ; 111: Syncfusion.SfCarousel.XForms.dll => 0x337e33b7c5b727ef => 75
	i64 3716579019761409177, ; 112: netstandard.dll => 0x3393f0ed5c8c5c99 => 2
	i64 3727469159507183293, ; 113: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 185
	i64 3730887114094830029, ; 114: Syncfusion.GridCommon.Portable.dll => 0x33c6c6102cb461cd => 67
	i64 3756217500168923014, ; 115: Syncfusion.SfBusyIndicator.XForms => 0x3420c3ea44aca786 => 73
	i64 3772598417116884899, ; 116: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 158
	i64 3869221888984012293, ; 117: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 39
	i64 3943415582112705276, ; 118: Syncfusion.Buttons.XForms.dll => 0x36b9d3942d916afc => 59
	i64 3955305636023511547, ; 119: Microsoft.AppCenter.Crashes.Android.Bindings.dll => 0x36e41185154829fb => 32
	i64 3966267475168208030, ; 120: System.Memory => 0x370b03412596249e => 248
	i64 4154383907710350974, ; 121: System.ComponentModel => 0x39a7562737acb67e => 13
	i64 4187479170553454871, ; 122: System.Linq.Expressions => 0x3a1cea1e912fa117 => 251
	i64 4201423742386704971, ; 123: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 152
	i64 4247996603072512073, ; 124: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 227
	i64 4248804899347366872, ; 125: Xamarin.AndroidX.Room.Common.dll => 0x3af6c98b798a03d8 => 187
	i64 4252163538099460320, ; 126: Xamarin.Android.Support.ViewPager.dll => 0x3b02b8357f4958e0 => 134
	i64 4334352720302891708, ; 127: Plugin.Iconize.dll => 0x3c26b6d5b0e6e2bc => 48
	i64 4349341163892612332, ; 128: Xamarin.Android.Support.DocumentFile => 0x3c5bf6bea8cd9cec => 120
	i64 4416987920449902723, ; 129: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0x3d4c4b1c879b9883 => 112
	i64 4424758928462204584, ; 130: Xamanimation.dll => 0x3d67e6cd53ba4ea8 => 102
	i64 4426591508050471694, ; 131: MR.Gestures => 0x3d6e6986031beb0e => 43
	i64 4525561845656915374, ; 132: System.ServiceModel.Internals => 0x3ece06856b710dae => 244
	i64 4636684751163556186, ; 133: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 200
	i64 4759461199762736555, ; 134: Xamarin.AndroidX.Lifecycle.Process.dll => 0x420d00be961cc5ab => 170
	i64 4782108999019072045, ; 135: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 143
	i64 4794310189461587505, ; 136: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 135
	i64 4795410492532947900, ; 137: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 195
	i64 4841234827713643511, ; 138: Xamarin.Android.Support.CoordinaterLayout => 0x432f856d041f03f7 => 115
	i64 4906396365959678531, ; 139: Syncfusion.SfPicker.XForms => 0x4417057fe84b4a43 => 84
	i64 4963205065368577818, ; 140: Xamarin.Android.Support.LocalBroadcastManager.dll => 0x44e0d8b5f4b6a71a => 125
	i64 4993330139331155028, ; 141: Syncfusion.SfRadialMenu.Android => 0x454bdf4e5115d454 => 87
	i64 5081566143765835342, ; 142: System.Resources.ResourceManager.dll => 0x4685597c05d06e4e => 4
	i64 5099468265966638712, ; 143: System.Resources.ResourceManager => 0x46c4f35ea8519678 => 4
	i64 5142919913060024034, ; 144: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 217
	i64 5155409377101935888, ; 145: Syncfusion.SfRadialMenu.XForms => 0x478bb18391e0f510 => 89
	i64 5178572682164047940, ; 146: Xamarin.Android.Support.Print.dll => 0x47ddfc6acbee1044 => 127
	i64 5203618020066742981, ; 147: Xamarin.Essentials => 0x4836f704f0e652c5 => 206
	i64 5205316157927637098, ; 148: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 176
	i64 5233983725610684227, ; 149: FastAndroidCamera => 0x48a2d877b5334f43 => 23
	i64 5256995213548036366, ; 150: Xamarin.Forms.Maps.Android.dll => 0x48f4994b4175a10e => 213
	i64 5280980186044710147, ; 151: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x4949cf7fd7123d03 => 168
	i64 5288341611614403055, ; 152: Xamarin.Android.Support.Interpolator.dll => 0x4963f6ad4b3179ef => 123
	i64 5348796042099802469, ; 153: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 177
	i64 5375264076663995773, ; 154: Xamarin.Forms.PancakeView => 0x4a98c632c779bd7d => 216
	i64 5376510917114486089, ; 155: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 198
	i64 5408338804355907810, ; 156: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 197
	i64 5439315836349573567, ; 157: Xamarin.Android.Support.Animated.Vector.Drawable.dll => 0x4b7c54ef36c5e9bf => 110
	i64 5446034149219586269, ; 158: System.Diagnostics.Debug => 0x4b94333452e150dd => 7
	i64 5451019430259338467, ; 159: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 150
	i64 5507995362134886206, ; 160: System.Core.dll => 0x4c705499688c873e => 91
	i64 5514426807633697079, ; 161: Xamarin.AndroidX.Sqlite => 0x4c872df700e5d937 => 192
	i64 5528247634813456972, ; 162: Plugin.LocalNotification.dll => 0x4cb847ef1773124c => 49
	i64 5574231584441077149, ; 163: Xamarin.AndroidX.Annotation.Jvm => 0x4d5ba617ae5f8d9d => 138
	i64 5619971803549996551, ; 164: Microsoft.AppCenter => 0x4dfe2694564f1607 => 34
	i64 5679624767254653100, ; 165: Syncfusion.SfProgressBar.XForms => 0x4ed214a245b968ac => 86
	i64 5692067934154308417, ; 166: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 202
	i64 5757522595884336624, ; 167: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 148
	i64 5759039185982771185, ; 168: Xamarin.AndroidX.Lifecycle.Service => 0x4fec37a0800ecff1 => 172
	i64 5767696078500135884, ; 169: Xamarin.Android.Support.Annotations.dll => 0x500af9065b6a03cc => 111
	i64 5775268978821181986, ; 170: Syncfusion.SfBusyIndicator.Android => 0x5025e0899cf83222 => 71
	i64 5814345312393086621, ; 171: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 182
	i64 5819465594466874502, ; 172: SignaturePad.Forms => 0x50c2e52014ce3486 => 56
	i64 5848635860608528381, ; 173: Syncfusion.SfPicker.Android => 0x512a8753ec2eaffd => 82
	i64 5896680224035167651, ; 174: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 169
	i64 6044705416426755068, ; 175: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0x53e31b8ccdff13fc => 129
	i64 6046773784300663497, ; 176: Syncfusion.SfRadialMenu.Android.dll => 0x53ea74b83a62b2c9 => 87
	i64 6085203216496545422, ; 177: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 218
	i64 6086316965293125504, ; 178: FormsViewGroup.dll => 0x5476f10882baef80 => 24
	i64 6092862891035488599, ; 179: Xamarin.Firebase.Measurement.Connector.dll => 0x548e32849d547157 => 210
	i64 6300241346327543539, ; 180: Xamarin.Firebase.Iid => 0x576ef41fd714fef3 => 208
	i64 6311200438583329442, ; 181: Xamarin.Android.Support.LocalBroadcastManager => 0x5795e35c580c82a2 => 125
	i64 6319713645133255417, ; 182: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 171
	i64 6401687960814735282, ; 183: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 167
	i64 6405879832841858445, ; 184: Xamarin.Android.Support.Vector.Drawable.dll => 0x58e641c4a660ad8d => 132
	i64 6431494048024938549, ; 185: Syncfusion.SfCarousel.XForms.Android.dll => 0x594141c2db90c835 => 74
	i64 6465768060024492319, ; 186: Syncfusion.SfListView.XForms => 0x59bb05cb21d3911f => 81
	i64 6504860066809920875, ; 187: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 144
	i64 6548213210057960872, ; 188: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 155
	i64 6554405243736097249, ; 189: Xamarin.GooglePlayServices.Stats => 0x5af5ecd7aad901e1 => 226
	i64 6557084851308642443, ; 190: Xamarin.AndroidX.Window.dll => 0x5aff71ee6c58c08b => 203
	i64 6560151584539558821, ; 191: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 40
	i64 6588599331800941662, ; 192: Xamarin.Android.Support.v4 => 0x5b6f682f335f045e => 130
	i64 6591024623626361694, ; 193: System.Web.Services.dll => 0x5b7805f9751a1b5e => 243
	i64 6591971792923354531, ; 194: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x5b7b636b7e9765a3 => 168
	i64 6659513131007730089, ; 195: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 163
	i64 6876862101832370452, ; 196: System.Xml.Linq => 0x5f6f85a57d108914 => 101
	i64 6878024704864574184, ; 197: Syncfusion.Cards.XForms.dll => 0x5f73a70719d05ae8 => 61
	i64 6894844156784520562, ; 198: System.Numerics.Vectors => 0x5faf683aead1ad72 => 96
	i64 7026608356547306326, ; 199: Syncfusion.Core.XForms.dll => 0x618387125bcb2356 => 63
	i64 7036436454368433159, ; 200: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 165
	i64 7103753931438454322, ; 201: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 162
	i64 7141281584637745974, ; 202: Xamarin.GooglePlayServices.Maps.dll => 0x631aedc3dd5f1b36 => 225
	i64 7141577505875122296, ; 203: System.Runtime.InteropServices.WindowsRuntime.dll => 0x631bfae7659b5878 => 17
	i64 7194160955514091247, ; 204: Xamarin.Android.Support.CursorAdapter.dll => 0x63d6cb45d266f6ef => 118
	i64 7270811800166795866, ; 205: System.Linq => 0x64e71ccf51a90a5a => 247
	i64 7270951509819434961, ; 206: Syncfusion.SfAutoComplete.XForms => 0x64e79be001e0a7d1 => 70
	i64 7291284685109936435, ; 207: Microsoft.AppCenter.Analytics => 0x652fd8ca4c394133 => 30
	i64 7338192458477945005, ; 208: System.Reflection => 0x65d67f295d0740ad => 6
	i64 7363614467969488359, ; 209: Xamarin.AndroidX.Sqlite.Framework.dll => 0x6630d058323f95e7 => 193
	i64 7364333345899356075, ; 210: DLToolkit.Forms.Controls.FlowListView => 0x66335e2901e51fab => 20
	i64 7385250113861300937, ; 211: Xamarin.Firebase.Iid.Interop.dll => 0x667dadd98e1db2c9 => 209
	i64 7488575175965059935, ; 212: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 101
	i64 7489048572193775167, ; 213: System.ObjectModel => 0x67ee71ff6b419e3f => 245
	i64 7602111570124318452, ; 214: System.Reactive => 0x698020320025a6f4 => 97
	i64 7635363394907363464, ; 215: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 212
	i64 7637365915383206639, ; 216: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 206
	i64 7654504624184590948, ; 217: System.Net.Http => 0x6a3a4366801b8264 => 94
	i64 7735176074855944702, ; 218: Microsoft.CSharp => 0x6b58dda848e391fe => 35
	i64 7735352534559001595, ; 219: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 229
	i64 7756332380610150586, ; 220: Xamarin.Google.AutoValue.Annotations => 0x6ba407349220c0ba => 221
	i64 7767211987177345230, ; 221: Syncfusion.SfPicker.Android.dll => 0x6bcaae265edc90ce => 82
	i64 7820441508502274321, ; 222: System.Data => 0x6c87ca1e14ff8111 => 15
	i64 7821246742157274664, ; 223: Xamarin.Android.Support.AsyncLayoutInflater => 0x6c8aa67926f72e28 => 112
	i64 7836164640616011524, ; 224: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 139
	i64 7842383726582361265, ; 225: Xamarin.AndroidX.Sqlite.dll => 0x6cd5be72d73eecb1 => 192
	i64 7875371864198757046, ; 226: AndHUD.dll => 0x6d4af0fc27ac3ab6 => 19
	i64 7879037620440914030, ; 227: Xamarin.Android.Support.v7.AppCompat.dll => 0x6d57f6f88a51d86e => 131
	i64 8043385360954670903, ; 228: eWarranty.resources.dll => 0x6f9fd85ebf47bf37 => 0
	i64 8044118961405839122, ; 229: System.ComponentModel.Composition => 0x6fa2739369944712 => 241
	i64 8064050204834738623, ; 230: System.Collections.dll => 0x6fe942efa61731bf => 5
	i64 8083354569033831015, ; 231: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 166
	i64 8087206902342787202, ; 232: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 92
	i64 8101777744205214367, ; 233: Xamarin.Android.Support.Annotations => 0x706f4beeec84729f => 111
	i64 8103644804370223335, ; 234: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 238
	i64 8113615946733131500, ; 235: System.Reflection.Extensions => 0x70995ab73cf916ec => 10
	i64 8167236081217502503, ; 236: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 26
	i64 8185542183669246576, ; 237: System.Collections => 0x7198e33f4794aa70 => 5
	i64 8187640529827139739, ; 238: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 232
	i64 8196541262927413903, ; 239: Xamarin.Android.Support.Interpolator => 0x71bff6d9fb9ec28f => 123
	i64 8258541458284035314, ; 240: eWarranty.Android => 0x729c3bb35fdb3cf2 => 1
	i64 8290740647658429042, ; 241: System.Runtime.Extensions => 0x730ea0b15c929a72 => 9
	i64 8385935383968044654, ; 242: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0x7460d3cd16cb566e => 108
	i64 8398329775253868912, ; 243: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 149
	i64 8400357532724379117, ; 244: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 181
	i64 8426919725312979251, ; 245: Xamarin.AndroidX.Lifecycle.Process => 0x74f26ed7aa033133 => 170
	i64 8428678171113854126, ; 246: Xamarin.Firebase.Iid.dll => 0x74f8ae23bb5494ae => 208
	i64 8465511506719290632, ; 247: Xamarin.Firebase.Messaging.dll => 0x757b89dcf7fc3508 => 211
	i64 8517710342570482946, ; 248: Syncfusion.Buttons.XForms.Android => 0x7634fc6d84959d02 => 58
	i64 8598790081731763592, ; 249: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x77550a055fc61d88 => 160
	i64 8601935802264776013, ; 250: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 197
	i64 8609060182490045521, ; 251: Square.OkIO.dll => 0x7779869f8b475c51 => 57
	i64 8626175481042262068, ; 252: Java.Interop => 0x77b654e585b55834 => 26
	i64 8638972117149407195, ; 253: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 35
	i64 8639588376636138208, ; 254: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 180
	i64 8684531736582871431, ; 255: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 240
	i64 8725526185868997716, ; 256: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 92
	i64 8808820144457481518, ; 257: Xamarin.Android.Support.Loader.dll => 0x7a3f374010b17d2e => 124
	i64 8844506025403580595, ; 258: Plugin.FirebasePushNotification => 0x7abdff5eb1fb80b3 => 47
	i64 8917102979740339192, ; 259: Xamarin.Android.Support.DocumentFile.dll => 0x7bbfe9ea4d000bf8 => 120
	i64 8951477988056063522, ; 260: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0x7c3a09cd9ccf5e22 => 184
	i64 8963482838182047088, ; 261: Syncfusion.SfProgressBar.XForms.dll => 0x7c64b0269826ad70 => 86
	i64 9031035476476434958, ; 262: Xamarin.KotlinX.Coroutines.Core.dll => 0x7d54aeead9541a0e => 233
	i64 9034105039140296321, ; 263: Syncfusion.SfChart.XForms => 0x7d5f96ab19861681 => 77
	i64 9238909584418939062, ; 264: Xamarin.AndroidX.Sqlite.Framework => 0x80373351333e20b6 => 193
	i64 9290408134796603763, ; 265: Xamarin.Forms.Material.dll => 0x80ee28f9d4f37173 => 215
	i64 9293890220217345133, ; 266: Syncfusion.SfAutoComplete.XForms.Android.dll => 0x80fa87ea0588246d => 69
	i64 9312692141327339315, ; 267: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 202
	i64 9324707631942237306, ; 268: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 140
	i64 9375789856415139806, ; 269: eWarranty.Core.dll => 0x821d7f330855c7de => 3
	i64 9646958908362757981, ; 270: Plugin.Multilingual.Abstractions.dll => 0x85e0e203efc0975d => 50
	i64 9653670174411988578, ; 271: Syncfusion.SfPicker.XForms.Android => 0x85f8b9e0549c1e62 => 83
	i64 9659729154652888475, ; 272: System.Text.RegularExpressions => 0x860e407c9991dd9b => 252
	i64 9662334977499516867, ; 273: System.Numerics.dll => 0x8617827802b0cfc3 => 95
	i64 9678050649315576968, ; 274: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 151
	i64 9704315356731487263, ; 275: Plugin.FirebasePushNotification.dll => 0x86aca766ba59341f => 47
	i64 9711637524876806384, ; 276: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 177
	i64 9738639507377523407, ; 277: eWarranty => 0x87269908d0d28acf => 22
	i64 9754517241374622406, ; 278: Syncfusion.SfAutoComplete.XForms.Android => 0x875f01bfd78ec2c6 => 69
	i64 9780093022148426479, ; 279: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x87b9dec9576efaef => 204
	i64 9780723996889434231, ; 280: AndHUD => 0x87bc1ca798bbc877 => 19
	i64 9796610708422913120, ; 281: Xamarin.Firebase.Iid.Interop => 0x87f48d88de55ec60 => 209
	i64 9808709177481450983, ; 282: Mono.Android.dll => 0x881f890734e555e7 => 42
	i64 9825649861376906464, ; 283: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 148
	i64 9834056768316610435, ; 284: System.Transactions.dll => 0x8879968718899783 => 242
	i64 9866412715007501892, ; 285: Xamarin.Android.Arch.Lifecycle.Common.dll => 0x88ec8a16fd6b6644 => 105
	i64 9875200773399460291, ; 286: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 223
	i64 9907349773706910547, ; 287: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x897dfa20b758db53 => 160
	i64 9933555792566666578, ; 288: System.Linq.Queryable.dll => 0x89db145cf475c552 => 14
	i64 9998632235833408227, ; 289: Mono.Security => 0x8ac2470b209ebae3 => 256
	i64 10038780035334861115, ; 290: System.Net.Http.dll => 0x8b50e941206af13b => 94
	i64 10226222362177979215, ; 291: Xamarin.Kotlin.StdLib.Jdk7 => 0x8dead70ebbc6434f => 230
	i64 10229024438826829339, ; 292: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 155
	i64 10303855825347935641, ; 293: Xamarin.Android.Support.Loader => 0x8efea647eeb3fd99 => 124
	i64 10321854143672141184, ; 294: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 228
	i64 10352330178246763130, ; 295: Xamarin.Firebase.Measurement.Connector => 0x8faadd72b7f4627a => 210
	i64 10360651442923773544, ; 296: System.Text.Encoding => 0x8fc86d98211c1e68 => 11
	i64 10363495123250631811, ; 297: Xamarin.Android.Support.Collections.dll => 0x8fd287e80cd8d483 => 113
	i64 10376576884623852283, ; 298: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 196
	i64 10406448008575299332, ; 299: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 234
	i64 10421511051509811956, ; 300: Xamarin.AndroidX.Room.Runtime.dll => 0x90a0a515f80ccaf4 => 189
	i64 10430153318873392755, ; 301: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 153
	i64 10566960649245365243, ; 302: System.Globalization.dll => 0x92a562b96dcd13fb => 249
	i64 10635644668885628703, ; 303: Xamarin.Android.Support.DrawerLayout.dll => 0x93996679ee34771f => 121
	i64 10679925812255520825, ; 304: Xamarin.AndroidX.Work.Runtime.dll => 0x9436b7f10b03f839 => 205
	i64 10714184849103829812, ; 305: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 9
	i64 10775409704848971057, ; 306: Xamarin.Forms.Maps => 0x9589f20936d1d531 => 214
	i64 10822644899632537592, ; 307: System.Linq.Queryable => 0x9631c23204ca5ff8 => 14
	i64 10847732767863316357, ; 308: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 141
	i64 10849603794298325860, ; 309: Xamarin.AndroidX.Room.Common => 0x9691892ad0e1cb64 => 187
	i64 10850923258212604222, ; 310: Xamarin.Android.Arch.Lifecycle.Runtime => 0x9696393672c9593e => 108
	i64 10878511855281532577, ; 311: Syncfusion.Cards.XForms.Android.dll => 0x96f83ce542ee6ea1 => 60
	i64 10964653383833615866, ; 312: System.Diagnostics.Tracing => 0x982a4628ccaffdfa => 253
	i64 11002576679268595294, ; 313: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 38
	i64 11019817191295005410, ; 314: Xamarin.AndroidX.Annotation.Jvm.dll => 0x98ee415998e1b2e2 => 138
	i64 11023048688141570732, ; 315: System.Core => 0x98f9bc61168392ac => 91
	i64 11037814507248023548, ; 316: System.Xml => 0x992e31d0412bf7fc => 100
	i64 11162124722117608902, ; 317: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 201
	i64 11177418026010201814, ; 318: XF.Material => 0x9b1e2a796262ced6 => 235
	i64 11226290749488709958, ; 319: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 40
	i64 11234217159698959754, ; 320: dotMorten.Xamarin.Forms.AutoSuggestBox.dll => 0x9be7f4fc3d744d8a => 21
	i64 11299661109949763898, ; 321: Xamarin.AndroidX.Collection.Jvm => 0x9cd075e94cda113a => 147
	i64 11340910727871153756, ; 322: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 154
	i64 11376461258732682436, ; 323: Xamarin.Android.Support.Compat => 0x9de14f3d5fc13cc4 => 114
	i64 11392833485892708388, ; 324: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 183
	i64 11395515702206878257, ; 325: XF.Material.dll => 0x9e250127b66d5231 => 235
	i64 11432101114902388181, ; 326: System.AppContext => 0x9ea6fb64e61a9dd5 => 255
	i64 11444370155346000636, ; 327: Xamarin.Forms.Maps.Android => 0x9ed292057b7afafc => 213
	i64 11472067811128429120, ; 328: Microsoft.AppCenter.Crashes.Android.Bindings => 0x9f34f8e48180ca40 => 32
	i64 11481714388108425262, ; 329: Syncfusion.SfComboBox.XForms => 0x9f573e673bb1b82e => 79
	i64 11485890710487134646, ; 330: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 254
	i64 11529969570048099689, ; 331: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 201
	i64 11530571088791430846, ; 332: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 39
	i64 11553412919618483556, ; 333: eWarranty.Core => 0xa055f7d67944b564 => 3
	i64 11578238080964724296, ; 334: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 165
	i64 11580057168383206117, ; 335: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 136
	i64 11591352189662810718, ; 336: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0xa0dcc167234c525e => 194
	i64 11597940890313164233, ; 337: netstandard => 0xa0f429ca8d1805c9 => 2
	i64 11660723344418086924, ; 338: Plugin.Iconize => 0xa1d33619c025200c => 48
	i64 11672361001936329215, ; 339: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 162
	i64 11683710219442713716, ; 340: ZXingNetMobile => 0xa224e08aa87bf474 => 237
	i64 11743665907891708234, ; 341: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 246
	i64 11758626982801240232, ; 342: Syncfusion.SfBusyIndicator.XForms.Android.dll => 0xa32f08f0e430f0a8 => 72
	i64 11834399401546345650, ; 343: Xamarin.Android.Support.SlidingPaneLayout.dll => 0xa43c3b8deb43ecb2 => 128
	i64 11854093697108963210, ; 344: Microsoft.AppCenter.Crashes.dll => 0xa48233696e606f8a => 33
	i64 11865714326292153359, ; 345: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa4ab7c5000e8440f => 107
	i64 11869220915266023700, ; 346: Syncfusion.SfAutoComplete.XForms.dll => 0xa4b7f1895f117114 => 70
	i64 12006736334756399793, ; 347: SignaturePad => 0xa6a07f1500ee4ab1 => 55
	i64 12102847907131387746, ; 348: System.Buffers => 0xa7f5f40c43256f62 => 90
	i64 12123043025855404482, ; 349: System.Reflection.Extensions.dll => 0xa83db366c0e359c2 => 10
	i64 12137774235383566651, ; 350: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 199
	i64 12212747205940921632, ; 351: Syncfusion.SfProgressBar.XForms.Android => 0xa97c64e0bdc0c520 => 85
	i64 12250081775278992142, ; 352: Microsoft.AppCenter.Analytics.Android.Bindings => 0xaa0108788cfdab0e => 29
	i64 12263794765274154115, ; 353: Microsoft.AppCenter.dll => 0xaa31c05cd6760483 => 34
	i64 12271526709721397701, ; 354: Syncfusion.SfPicker.XForms.dll => 0xaa4d388670a979c5 => 84
	i64 12361596062003817520, ; 355: Plugin.Multilingual.dll => 0xab8d361fb49aec30 => 51
	i64 12388767885335911387, ; 356: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0xabedbec0d236dbdb => 107
	i64 12414299427252656003, ; 357: Xamarin.Android.Support.Compat.dll => 0xac48738e28bad783 => 114
	i64 12450197211230333945, ; 358: SignaturePad.dll => 0xacc7fc664ef16bf9 => 55
	i64 12451044538927396471, ; 359: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 161
	i64 12466513435562512481, ; 360: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 175
	i64 12487638416075308985, ; 361: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 156
	i64 12488608402635344228, ; 362: Lottie.Android => 0xad50732cba09c964 => 27
	i64 12538491095302438457, ; 363: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 145
	i64 12550732019250633519, ; 364: System.IO.Compression => 0xae2d28465e8e1b2f => 239
	i64 12700543734426720211, ; 365: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 146
	i64 12753841065332862057, ; 366: Xamarin.AndroidX.Window => 0xb0febee04cf46c69 => 203
	i64 12828192437253469131, ; 367: Xamarin.Kotlin.StdLib.Jdk8.dll => 0xb206e50e14d873cb => 231
	i64 12832250852553794196, ; 368: Syncfusion.SfBusyIndicator.XForms.dll => 0xb2155029872c2294 => 73
	i64 12843321153144804894, ; 369: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 41
	i64 12843770487262409629, ; 370: System.AppContext.dll => 0xb23e3d357debf39d => 255
	i64 12952608645614506925, ; 371: Xamarin.Android.Support.Core.Utils => 0xb3c0e8eff48193ad => 117
	i64 12963446364377008305, ; 372: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 12
	i64 13129914918964716986, ; 373: Xamarin.AndroidX.Emoji2.dll => 0xb636d40db3fe65ba => 159
	i64 13341214209551883571, ; 374: Shiny.Notifications => 0xb92583a388bbdd33 => 54
	i64 13358059602087096138, ; 375: Xamarin.Android.Support.Fragment.dll => 0xb9615c6f1ee5af4a => 122
	i64 13370190879438847839, ; 376: Syncfusion.SfRadialMenu.XForms.Android.dll => 0xb98c75c43c1ebf5f => 88
	i64 13370592475155966277, ; 377: System.Runtime.Serialization => 0xb98de304062ea945 => 18
	i64 13391361154981494717, ; 378: Syncfusion.Buttons.XForms.Android.dll => 0xb9d7ac051da2ffbd => 58
	i64 13401370062847626945, ; 379: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 199
	i64 13404347523447273790, ; 380: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 149
	i64 13407771833520603066, ; 381: Syncfusion.SfRadialMenu.XForms.Android => 0xba11f971f67bbfba => 88
	i64 13454009404024712428, ; 382: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 222
	i64 13465488254036897740, ; 383: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 229
	i64 13491513212026656886, ; 384: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 142
	i64 13572454107664307259, ; 385: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 185
	i64 13622732128915678507, ; 386: Syncfusion.Core.XForms.Android => 0xbd0daab1e651e52b => 62
	i64 13629449975987305271, ; 387: Microsoft.AppCenter.Android.Bindings => 0xbd25888a8eadfb37 => 31
	i64 13647894001087880694, ; 388: System.Data.dll => 0xbd670f48cb071df6 => 15
	i64 13713329104121190199, ; 389: System.Dynamic.Runtime => 0xbe4f8829f32b5737 => 250
	i64 13849821837823696015, ; 390: Syncfusion.Expander.XForms.Android => 0xc0347394fdeddc8f => 65
	i64 13852575513600495870, ; 391: ImageCircle.Forms.Plugin.dll => 0xc03e3c09186e90fe => 25
	i64 13959074834287824816, ; 392: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 161
	i64 13967638549803255703, ; 393: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 217
	i64 13970307180132182141, ; 394: Syncfusion.Licensing => 0xc1e0805ccade287d => 68
	i64 13987974187833695008, ; 395: Xamarin.AndroidX.Lifecycle.Service.dll => 0xc21f446991291b20 => 172
	i64 14061024831517255851, ; 396: Syncfusion.SfComboBox.XForms.Android => 0xc322cb95f48868ab => 78
	i64 14124974489674258913, ; 397: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 145
	i64 14125464355221830302, ; 398: System.Threading.dll => 0xc407bafdbc707a9e => 8
	i64 14172845254133543601, ; 399: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 178
	i64 14261073672896646636, ; 400: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 183
	i64 14327695147300244862, ; 401: System.Reflection.dll => 0xc6d632d338eb4d7e => 6
	i64 14369828458497533121, ; 402: Xamarin.Android.Support.Vector.Drawable => 0xc76be2d9300b64c1 => 132
	i64 14400856865250966808, ; 403: Xamarin.Android.Support.Core.UI => 0xc7da1f051a877d18 => 116
	i64 14451964210230602902, ; 404: Syncfusion.Cards.XForms.Android => 0xc88fb0e121742c96 => 60
	i64 14486659737292545672, ; 405: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 169
	i64 14495724990987328804, ; 406: Xamarin.AndroidX.ResourceInspection.Annotation => 0xc92b2913e18d5d24 => 186
	i64 14536303476482288245, ; 407: Syncfusion.Expander.XForms => 0xc9bb52fec700aa75 => 66
	i64 14538127318538747197, ; 408: Syncfusion.Licensing.dll => 0xc9c1cdc518e77d3d => 68
	i64 14644440854989303794, ; 409: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 176
	i64 14661790646341542033, ; 410: Xamarin.Android.Support.SwipeRefreshLayout => 0xcb7924e94e552091 => 129
	i64 14669215534098758659, ; 411: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 37
	i64 14789919016435397935, ; 412: Xamarin.Firebase.Common.dll => 0xcd4058fc2f6d352f => 207
	i64 14792063746108907174, ; 413: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 222
	i64 14809388726477333247, ; 414: Xamarin.GooglePlayServices.Stats.dll => 0xcd8584954e5b22ff => 226
	i64 14852515768018889994, ; 415: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 154
	i64 14954917835170835695, ; 416: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 36
	i64 14970123681643361337, ; 417: Plugin.Multilingual.Abstractions => 0xcfc0902c6003f439 => 50
	i64 14987728460634540364, ; 418: System.IO.Compression.dll => 0xcfff1ba06622494c => 239
	i64 14988210264188246988, ; 419: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 156
	i64 15076659072870671916, ; 420: System.ObjectModel.dll => 0xd13b0d8c1620662c => 245
	i64 15133485256822086103, ; 421: System.Linq.dll => 0xd204f0a9127dd9d7 => 247
	i64 15150743910298169673, ; 422: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xd2424150783c3149 => 184
	i64 15188640517174936311, ; 423: Xamarin.Android.Arch.Core.Common => 0xd2c8e413d75142f7 => 103
	i64 15234786388537674379, ; 424: System.Dynamic.Runtime.dll => 0xd36cd580c5be8a8b => 250
	i64 15246441518555807158, ; 425: Xamarin.Android.Arch.Core.Common.dll => 0xd3963dc832493db6 => 103
	i64 15279429628684179188, ; 426: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 232
	i64 15326820765897713587, ; 427: Xamarin.Android.Arch.Core.Runtime.dll => 0xd4b3ce481769e7b3 => 104
	i64 15370334346939861994, ; 428: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 153
	i64 15377983283090003614, ; 429: Syncfusion.SfBusyIndicator.Android.dll => 0xd5699251e679969e => 71
	i64 15391712275433856905, ; 430: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 36
	i64 15423352120420908645, ; 431: Syncfusion.SfComboBox.XForms.Android.dll => 0xd60ac1097f74be65 => 78
	i64 15457813392950723921, ; 432: Xamarin.Android.Support.Media.Compat => 0xd6852f61c31a8551 => 126
	i64 15526743539506359484, ; 433: System.Text.Encoding.dll => 0xd77a12fc26de2cbc => 11
	i64 15568534730848034786, ; 434: Xamarin.Android.Support.VersionedParcelable.dll => 0xd80e8bda21875fe2 => 133
	i64 15582737692548360875, ; 435: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 174
	i64 15609085926864131306, ; 436: System.dll => 0xd89e9cf3334914ea => 93
	i64 15777549416145007739, ; 437: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 191
	i64 15810740023422282496, ; 438: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 219
	i64 15817206913877585035, ; 439: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 246
	i64 15930129725311349754, ; 440: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 227
	i64 15963349826457351533, ; 441: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 257
	i64 16106398470792018018, ; 442: Syncfusion.Expander.XForms.Android.dll => 0xdf856c12e673f862 => 65
	i64 16107354805249926211, ; 443: ZXingNetMobile.dll => 0xdf88d1dade1a6443 => 237
	i64 16119456071779071829, ; 444: FastAndroidCamera.dll => 0xdfb3cfe48ae7b755 => 23
	i64 16147035330738724941, ; 445: Xamarin.AndroidX.Room.Room.Ktx.dll => 0xe015cb15285d204d => 188
	i64 16150183177059685051, ; 446: Syncfusion.SfChart.XForms.dll => 0xe020fa083e21d2bb => 77
	i64 16154507427712707110, ; 447: System => 0xe03056ea4e39aa26 => 93
	i64 16186751512479001459, ; 448: eWarranty.Android.dll => 0xe0a2e4bd50d3eb73 => 1
	i64 16242842420508142678, ; 449: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe16a2b1f8908ac56 => 115
	i64 16274182383641215830, ; 450: zxing.dll => 0xe1d982a752dac356 => 236
	i64 16321164108206115771, ; 451: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 38
	i64 16386247429361017669, ; 452: eWarranty.dll => 0xe367a5380cb8a345 => 22
	i64 16423015068819898779, ; 453: Xamarin.Kotlin.StdLib.Jdk8 => 0xe3ea453135e5c19b => 231
	i64 16471792842892863418, ; 454: DLToolkit.Forms.Controls.FlowListView.dll => 0xe4979051be7367ba => 20
	i64 16552427520763284698, ; 455: Syncfusion.SfChart.XForms.Android => 0xe5b60921b17eccda => 76
	i64 16565028646146589191, ; 456: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 241
	i64 16621146507174665210, ; 457: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 150
	i64 16677317093839702854, ; 458: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 181
	i64 16710582062585122022, ; 459: dotMorten.Xamarin.Forms.AutoSuggestBox => 0xe7e7e9d976668ce6 => 21
	i64 16740690081460163056, ; 460: Syncfusion.DataSource.Portable.dll => 0xe852e0eee05691f0 => 64
	i64 16767985610513713374, ; 461: Xamarin.Android.Arch.Core.Runtime => 0xe8b3da12798808de => 104
	i64 16787552971463248837, ; 462: Syncfusion.SfPicker.XForms.Android.dll => 0xe8f95e7bb81ecbc5 => 83
	i64 16822611501064131242, ; 463: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 238
	i64 16833383113903931215, ; 464: mscorlib => 0xe99c30c1484d7f4f => 44
	i64 16866861824412579935, ; 465: System.Runtime.InteropServices.WindowsRuntime => 0xea132176ffb5785f => 17
	i64 16890310621557459193, ; 466: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 252
	i64 16932527889823454152, ; 467: Xamarin.Android.Support.Core.Utils.dll => 0xeafc6c67465253c8 => 117
	i64 17009591894298689098, ; 468: Xamarin.Android.Support.Animated.Vector.Drawable => 0xec0e35b50a097e4a => 110
	i64 17024911836938395553, ; 469: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 137
	i64 17031351772568316411, ; 470: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 179
	i64 17037200463775726619, ; 471: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 164
	i64 17040771374769818752, ; 472: zxing => 0xec7cfb478bcccc80 => 236
	i64 17124705692820578889, ; 473: Lottie.Forms => 0xeda72d18d7ae2249 => 28
	i64 17285063141349522879, ; 474: Rg.Plugins.Popup => 0xefe0e158cc55fdbf => 52
	i64 17333249706306540043, ; 475: System.Diagnostics.Tracing.dll => 0xf08c12c5bb8b920b => 253
	i64 17338600258603746468, ; 476: Syncfusion.SfListView.XForms.dll => 0xf09f1512449284a4 => 81
	i64 17342427504449389352, ; 477: Syncfusion.SfCarousel.XForms => 0xf0acadee61ab8328 => 75
	i64 17383232329670771222, ; 478: Xamarin.Android.Support.CustomView.dll => 0xf13da5b41a1cc216 => 119
	i64 17428701562824544279, ; 479: Xamarin.Android.Support.Core.UI.dll => 0xf1df2fbaec73d017 => 116
	i64 17483646997724851973, ; 480: Xamarin.Android.Support.ViewPager => 0xf2a2644fe5b6ef05 => 134
	i64 17524135665394030571, ; 481: Xamarin.Android.Support.Print => 0xf3323c8a739097eb => 127
	i64 17544493274320527064, ; 482: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 143
	i64 17627500474728259406, ; 483: System.Globalization => 0xf4a176498a351f4e => 249
	i64 17666959971718154066, ; 484: Xamarin.Android.Support.CustomView => 0xf52da67d9f4e4752 => 119
	i64 17685921127322830888, ; 485: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 7
	i64 17704177640604968747, ; 486: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 175
	i64 17710060891934109755, ; 487: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 173
	i64 17712670374920797664, ; 488: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 254
	i64 17760961058993581169, ; 489: Xamarin.Android.Arch.Lifecycle.Common => 0xf67b9bfb46dbac71 => 105
	i64 17816041456001989629, ; 490: Xamarin.Forms.Maps.dll => 0xf73f4b4f90a1bbfd => 214
	i64 17827832363535584534, ; 491: Xamarin.Forms.PancakeView.dll => 0xf7692f1427c04d16 => 216
	i64 17838668724098252521, ; 492: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 90
	i64 17841643939744178149, ; 493: Xamarin.Android.Arch.Lifecycle.ViewModel => 0xf79a40a25573dfe5 => 109
	i64 17865949717230441556, ; 494: Xamarin.AndroidX.Room.Runtime => 0xf7f09a9c2682d454 => 189
	i64 17882897186074144999, ; 495: FormsViewGroup => 0xf82cd03e3ac830e7 => 24
	i64 17891337867145587222, ; 496: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 228
	i64 17892495832318972303, ; 497: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 219
	i64 17898189338132230373, ; 498: Syncfusion.SfRadialMenu.XForms.dll => 0xf863245fd60e30e5 => 89
	i64 17916084515058333260, ; 499: eWarranty.resources => 0xf8a2b7f165edb64c => 0
	i64 17928294245072900555, ; 500: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 240
	i64 17958105683855786126, ; 501: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xf93801f92d25c08e => 106
	i64 17969331831154222830, ; 502: Xamarin.GooglePlayServices.Maps => 0xf95fe418471126ee => 225
	i64 17986907704309214542, ; 503: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 224
	i64 18025913125965088385, ; 504: System.Threading => 0xfa28e87b91334681 => 8
	i64 18116111925905154859, ; 505: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 142
	i64 18121036031235206392, ; 506: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 179
	i64 18129453464017766560, ; 507: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 244
	i64 18245806341561545090, ; 508: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 16
	i64 18260797123374478311, ; 509: Xamarin.AndroidX.Emoji2 => 0xfd6b623bde35f3e7 => 159
	i64 18273040030599805019, ; 510: Shiny.Notifications.dll => 0xfd96e117d664f85b => 54
	i64 18301997741680159453, ; 511: Xamarin.Android.Support.CursorAdapter => 0xfdfdc1fa58d8eadd => 118
	i64 18305135509493619199, ; 512: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 180
	i64 18337470502355292274, ; 513: Xamarin.Firebase.Messaging => 0xfe7bc8440c175072 => 211
	i64 18348054648539995910, ; 514: MR.Gestures.dll => 0xfea1627d9dae5f06 => 43
	i64 18380184030268848184 ; 515: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 200
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [516 x i32] [
	i32 158, i32 59, i32 49, i32 215, i32 41, i32 42, i32 251, i32 146, ; 0..7
	i32 61, i32 190, i32 147, i32 52, i32 191, i32 152, i32 25, i32 97, ; 8..15
	i32 30, i32 109, i32 171, i32 223, i32 12, i32 163, i32 72, i32 80, ; 16..23
	i32 13, i32 113, i32 29, i32 106, i32 157, i32 242, i32 218, i32 256, ; 24..31
	i32 53, i32 220, i32 66, i32 64, i32 141, i32 122, i32 18, i32 79, ; 32..39
	i32 56, i32 133, i32 221, i32 204, i32 139, i32 174, i32 164, i32 45, ; 40..47
	i32 248, i32 131, i32 102, i32 140, i32 188, i32 190, i32 136, i32 130, ; 48..55
	i32 173, i32 257, i32 230, i32 63, i32 67, i32 45, i32 178, i32 74, ; 56..63
	i32 144, i32 31, i32 233, i32 85, i32 157, i32 243, i32 16, i32 186, ; 64..71
	i32 167, i32 98, i32 62, i32 151, i32 198, i32 99, i32 27, i32 135, ; 72..79
	i32 100, i32 44, i32 37, i32 182, i32 80, i32 33, i32 98, i32 194, ; 80..87
	i32 46, i32 128, i32 212, i32 121, i32 220, i32 126, i32 57, i32 76, ; 88..95
	i32 28, i32 166, i32 137, i32 53, i32 96, i32 205, i32 234, i32 207, ; 96..103
	i32 224, i32 196, i32 195, i32 51, i32 95, i32 99, i32 46, i32 75, ; 104..111
	i32 2, i32 185, i32 67, i32 73, i32 158, i32 39, i32 59, i32 32, ; 112..119
	i32 248, i32 13, i32 251, i32 152, i32 227, i32 187, i32 134, i32 48, ; 120..127
	i32 120, i32 112, i32 102, i32 43, i32 244, i32 200, i32 170, i32 143, ; 128..135
	i32 135, i32 195, i32 115, i32 84, i32 125, i32 87, i32 4, i32 4, ; 136..143
	i32 217, i32 89, i32 127, i32 206, i32 176, i32 23, i32 213, i32 168, ; 144..151
	i32 123, i32 177, i32 216, i32 198, i32 197, i32 110, i32 7, i32 150, ; 152..159
	i32 91, i32 192, i32 49, i32 138, i32 34, i32 86, i32 202, i32 148, ; 160..167
	i32 172, i32 111, i32 71, i32 182, i32 56, i32 82, i32 169, i32 129, ; 168..175
	i32 87, i32 218, i32 24, i32 210, i32 208, i32 125, i32 171, i32 167, ; 176..183
	i32 132, i32 74, i32 81, i32 144, i32 155, i32 226, i32 203, i32 40, ; 184..191
	i32 130, i32 243, i32 168, i32 163, i32 101, i32 61, i32 96, i32 63, ; 192..199
	i32 165, i32 162, i32 225, i32 17, i32 118, i32 247, i32 70, i32 30, ; 200..207
	i32 6, i32 193, i32 20, i32 209, i32 101, i32 245, i32 97, i32 212, ; 208..215
	i32 206, i32 94, i32 35, i32 229, i32 221, i32 82, i32 15, i32 112, ; 216..223
	i32 139, i32 192, i32 19, i32 131, i32 0, i32 241, i32 5, i32 166, ; 224..231
	i32 92, i32 111, i32 238, i32 10, i32 26, i32 5, i32 232, i32 123, ; 232..239
	i32 1, i32 9, i32 108, i32 149, i32 181, i32 170, i32 208, i32 211, ; 240..247
	i32 58, i32 160, i32 197, i32 57, i32 26, i32 35, i32 180, i32 240, ; 248..255
	i32 92, i32 124, i32 47, i32 120, i32 184, i32 86, i32 233, i32 77, ; 256..263
	i32 193, i32 215, i32 69, i32 202, i32 140, i32 3, i32 50, i32 83, ; 264..271
	i32 252, i32 95, i32 151, i32 47, i32 177, i32 22, i32 69, i32 204, ; 272..279
	i32 19, i32 209, i32 42, i32 148, i32 242, i32 105, i32 223, i32 160, ; 280..287
	i32 14, i32 256, i32 94, i32 230, i32 155, i32 124, i32 228, i32 210, ; 288..295
	i32 11, i32 113, i32 196, i32 234, i32 189, i32 153, i32 249, i32 121, ; 296..303
	i32 205, i32 9, i32 214, i32 14, i32 141, i32 187, i32 108, i32 60, ; 304..311
	i32 253, i32 38, i32 138, i32 91, i32 100, i32 201, i32 235, i32 40, ; 312..319
	i32 21, i32 147, i32 154, i32 114, i32 183, i32 235, i32 255, i32 213, ; 320..327
	i32 32, i32 79, i32 254, i32 201, i32 39, i32 3, i32 165, i32 136, ; 328..335
	i32 194, i32 2, i32 48, i32 162, i32 237, i32 246, i32 72, i32 128, ; 336..343
	i32 33, i32 107, i32 70, i32 55, i32 90, i32 10, i32 199, i32 85, ; 344..351
	i32 29, i32 34, i32 84, i32 51, i32 107, i32 114, i32 55, i32 161, ; 352..359
	i32 175, i32 156, i32 27, i32 145, i32 239, i32 146, i32 203, i32 231, ; 360..367
	i32 73, i32 41, i32 255, i32 117, i32 12, i32 159, i32 54, i32 122, ; 368..375
	i32 88, i32 18, i32 58, i32 199, i32 149, i32 88, i32 222, i32 229, ; 376..383
	i32 142, i32 185, i32 62, i32 31, i32 15, i32 250, i32 65, i32 25, ; 384..391
	i32 161, i32 217, i32 68, i32 172, i32 78, i32 145, i32 8, i32 178, ; 392..399
	i32 183, i32 6, i32 132, i32 116, i32 60, i32 169, i32 186, i32 66, ; 400..407
	i32 68, i32 176, i32 129, i32 37, i32 207, i32 222, i32 226, i32 154, ; 408..415
	i32 36, i32 50, i32 239, i32 156, i32 245, i32 247, i32 184, i32 103, ; 416..423
	i32 250, i32 103, i32 232, i32 104, i32 153, i32 71, i32 36, i32 78, ; 424..431
	i32 126, i32 11, i32 133, i32 174, i32 93, i32 191, i32 219, i32 246, ; 432..439
	i32 227, i32 257, i32 65, i32 237, i32 23, i32 188, i32 77, i32 93, ; 440..447
	i32 1, i32 115, i32 236, i32 38, i32 22, i32 231, i32 20, i32 76, ; 448..455
	i32 241, i32 150, i32 181, i32 21, i32 64, i32 104, i32 83, i32 238, ; 456..463
	i32 44, i32 17, i32 252, i32 117, i32 110, i32 137, i32 179, i32 164, ; 464..471
	i32 236, i32 28, i32 52, i32 253, i32 81, i32 75, i32 119, i32 116, ; 472..479
	i32 134, i32 127, i32 143, i32 249, i32 119, i32 7, i32 175, i32 173, ; 480..487
	i32 254, i32 105, i32 214, i32 216, i32 90, i32 109, i32 189, i32 24, ; 488..495
	i32 228, i32 219, i32 89, i32 0, i32 240, i32 106, i32 225, i32 224, ; 496..503
	i32 8, i32 142, i32 179, i32 244, i32 16, i32 159, i32 54, i32 118, ; 504..511
	i32 180, i32 211, i32 43, i32 200 ; 512..515
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
