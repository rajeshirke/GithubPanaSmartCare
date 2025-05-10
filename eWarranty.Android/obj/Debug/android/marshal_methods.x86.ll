; ModuleID = 'obj/Debug/android/marshal_methods.x86.ll'
source_filename = "obj/Debug/android/marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [516 x i32] [
	i32 5009434, ; 0: Syncfusion.Cards.XForms.Android => 0x4c701a => 60
	i32 6293305, ; 1: Syncfusion.SfRadialMenu.Android => 0x600739 => 87
	i32 32687329, ; 2: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 171
	i32 34715100, ; 3: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 222
	i32 39109920, ; 4: Newtonsoft.Json.dll => 0x254c520 => 45
	i32 57263871, ; 5: Xamarin.Forms.Core.dll => 0x369c6ff => 212
	i32 57967248, ; 6: Xamarin.Android.Support.VersionedParcelable.dll => 0x3748290 => 133
	i32 99762151, ; 7: Syncfusion.Buttons.XForms.dll => 0x5f23fe7 => 59
	i32 99966887, ; 8: Xamarin.Firebase.Iid.dll => 0x5f55fa7 => 208
	i32 101534019, ; 9: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 191
	i32 103826079, ; 10: XF.Material.dll => 0x630429f => 235
	i32 117431740, ; 11: System.Runtime.InteropServices => 0x6ffddbc => 254
	i32 120558881, ; 12: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 191
	i32 134690465, ; 13: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 230
	i32 148395041, ; 14: Lottie.Forms.dll => 0x8d85421 => 28
	i32 160529393, ; 15: Xamarin.Android.Arch.Core.Common => 0x9917bf1 => 103
	i32 165246403, ; 16: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 146
	i32 166922606, ; 17: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 114
	i32 172012715, ; 18: FastAndroidCamera.dll => 0xa40b4ab => 23
	i32 182336117, ; 19: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 195
	i32 201930040, ; 20: Xamarin.Android.Arch.Core.Runtime => 0xc093538 => 104
	i32 205061960, ; 21: System.ComponentModel => 0xc38ff48 => 13
	i32 209399409, ; 22: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 144
	i32 212497893, ; 23: Xamarin.Forms.Maps.Android => 0xcaa75e5 => 213
	i32 219130465, ; 24: Xamarin.Android.Support.v4 => 0xd0faa61 => 130
	i32 220171995, ; 25: System.Diagnostics.Debug => 0xd1f8edb => 7
	i32 230216969, ; 26: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 164
	i32 230752869, ; 27: Microsoft.CSharp.dll => 0xdc10265 => 35
	i32 231814094, ; 28: System.Globalization => 0xdd133ce => 249
	i32 232815796, ; 29: System.Web.Services => 0xde07cb4 => 243
	i32 261689757, ; 30: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 150
	i32 278686392, ; 31: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 169
	i32 280482487, ; 32: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 162
	i32 287869112, ; 33: Syncfusion.SfChart.XForms.dll => 0x112888b8 => 77
	i32 307891448, ; 34: Xamarin.AndroidX.Work.Runtime.dll => 0x125a0cf8 => 205
	i32 318968648, ; 35: Xamarin.AndroidX.Activity.dll => 0x13031348 => 135
	i32 319314094, ; 36: Xamarin.Forms.Maps => 0x130858ae => 214
	i32 321597661, ; 37: System.Numerics => 0x132b30dd => 95
	i32 332531999, ; 38: Syncfusion.SfBusyIndicator.XForms.Android => 0x13d2091f => 72
	i32 342366114, ; 39: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 166
	i32 377964854, ; 40: Syncfusion.SfAutoComplete.XForms => 0x16874936 => 70
	i32 381494705, ; 41: Xamarin.Forms.Material => 0x16bd25b1 => 215
	i32 385762202, ; 42: System.Memory.dll => 0x16fe439a => 248
	i32 388313361, ; 43: Xamarin.Android.Support.Animated.Vector.Drawable => 0x17253111 => 110
	i32 389971796, ; 44: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 116
	i32 441335492, ; 45: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 149
	i32 442521989, ; 46: Xamarin.Essentials => 0x1a605985 => 206
	i32 442565967, ; 47: System.Collections => 0x1a61054f => 5
	i32 450948140, ; 48: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 161
	i32 465846621, ; 49: mscorlib => 0x1bc4415d => 44
	i32 469710990, ; 50: System.dll => 0x1bff388e => 93
	i32 476646585, ; 51: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 162
	i32 486930444, ; 52: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 176
	i32 498788369, ; 53: System.ObjectModel => 0x1dbae811 => 245
	i32 504143952, ; 54: Plugin.LocalNotification.dll => 0x1e0ca050 => 49
	i32 506502624, ; 55: eWarranty.Android.dll => 0x1e309de0 => 1
	i32 513247710, ; 56: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 41
	i32 514659665, ; 57: Xamarin.Android.Support.Compat => 0x1ead1551 => 114
	i32 524864063, ; 58: Xamarin.Android.Support.Print => 0x1f48ca3f => 127
	i32 526420162, ; 59: System.Transactions.dll => 0x1f6088c2 => 242
	i32 527452488, ; 60: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 230
	i32 530272170, ; 61: System.Linq.Queryable => 0x1f9b4faa => 14
	i32 532697492, ; 62: Syncfusion.SfListView.XForms => 0x1fc05194 => 81
	i32 535134469, ; 63: Syncfusion.SfBusyIndicator.Android => 0x1fe58105 => 71
	i32 539058512, ; 64: Microsoft.Extensions.Logging => 0x20216150 => 39
	i32 542030372, ; 65: Xamarin.GooglePlayServices.Stats => 0x204eba24 => 226
	i32 545304856, ; 66: System.Runtime.Extensions => 0x2080b118 => 9
	i32 555173402, ; 67: Syncfusion.SfPicker.XForms.Android => 0x2117461a => 83
	i32 569601784, ; 68: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 204
	i32 605376203, ; 69: System.IO.Compression.FileSystem => 0x24154ecb => 240
	i32 610194910, ; 70: System.Reactive.dll => 0x245ed5de => 97
	i32 627609679, ; 71: Xamarin.AndroidX.CustomView => 0x2568904f => 155
	i32 639843206, ; 72: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 160
	i32 663517072, ; 73: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 200
	i32 666292255, ; 74: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 141
	i32 672442732, ; 75: System.Collections.Concurrent => 0x2814a96c => 16
	i32 690569205, ; 76: System.Xml.Linq.dll => 0x29293ff5 => 101
	i32 691348768, ; 77: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 232
	i32 692692150, ; 78: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 111
	i32 695102255, ; 79: Syncfusion.SfListView.XForms.dll => 0x296e6b2f => 81
	i32 700284507, ; 80: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 228
	i32 707987836, ; 81: Syncfusion.Cards.XForms.dll => 0x2a33097c => 61
	i32 719061231, ; 82: Syncfusion.Core.XForms.dll => 0x2adc00ef => 63
	i32 720511267, ; 83: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 231
	i32 721481609, ; 84: Microsoft.AppCenter.dll => 0x2b00ef89 => 34
	i32 729844822, ; 85: Syncfusion.SfComboBox.XForms.Android => 0x2b808c56 => 78
	i32 732016536, ; 86: Shiny.Core => 0x2ba1af98 => 53
	i32 775507847, ; 87: System.IO.Compression => 0x2e394f87 => 239
	i32 782533833, ; 88: Xamarin.Google.AutoValue.Annotations.dll => 0x2ea484c9 => 221
	i32 789151979, ; 89: Microsoft.Extensions.Options => 0x2f0980eb => 40
	i32 791612551, ; 90: DLToolkit.Forms.Controls.FlowListView => 0x2f2f0c87 => 20
	i32 801787702, ; 91: Xamarin.Android.Support.Interpolator => 0x2fca4f36 => 123
	i32 802720955, ; 92: SignaturePad => 0x2fd88cbb => 55
	i32 807930345, ; 93: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 168
	i32 809851609, ; 94: System.Drawing.Common.dll => 0x30455ad9 => 12
	i32 836755697, ; 95: Xamarin.AndroidX.Lifecycle.Service => 0x31dfe0f1 => 172
	i32 843511501, ; 96: Xamarin.AndroidX.Print => 0x3246f6cd => 183
	i32 865465478, ; 97: zxing.dll => 0x3395f486 => 236
	i32 877678880, ; 98: System.Globalization.dll => 0x34505120 => 249
	i32 882883187, ; 99: Xamarin.Android.Support.v4.dll => 0x349fba73 => 130
	i32 898563296, ; 100: Microsoft.AppCenter.Crashes.Android.Bindings => 0x358efce0 => 32
	i32 902159924, ; 101: Rg.Plugins.Popup => 0x35c5de34 => 52
	i32 903406257, ; 102: SignaturePad.dll => 0x35d8e2b1 => 55
	i32 916714535, ; 103: Xamarin.Android.Support.Print.dll => 0x36a3f427 => 127
	i32 926997726, ; 104: Plugin.Multilingual.Abstractions => 0x3740dcde => 50
	i32 928116545, ; 105: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 222
	i32 948616524, ; 106: MR.Gestures => 0x388abd4c => 43
	i32 954665006, ; 107: Syncfusion.SfRadialMenu.XForms.Android.dll => 0x38e7082e => 88
	i32 955402788, ; 108: Newtonsoft.Json => 0x38f24a24 => 45
	i32 956575887, ; 109: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 231
	i32 957807352, ; 110: Plugin.CurrentActivity => 0x3916faf8 => 46
	i32 958213972, ; 111: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 126
	i32 961995525, ; 112: Square.OkIO.dll => 0x3956e305 => 57
	i32 967690846, ; 113: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 166
	i32 974778368, ; 114: FormsViewGroup.dll => 0x3a19f000 => 24
	i32 975236339, ; 115: System.Diagnostics.Tracing => 0x3a20ecf3 => 253
	i32 987342438, ; 116: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0x3ad9a666 => 107
	i32 992768348, ; 117: System.Collections.dll => 0x3b2c715c => 5
	i32 993064525, ; 118: Syncfusion.SfCarousel.XForms.Android => 0x3b30f64d => 74
	i32 1012816738, ; 119: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 190
	i32 1028951442, ; 120: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 36
	i32 1031141475, ; 121: Microsoft.AppCenter.Analytics => 0x3d75f863 => 30
	i32 1035644815, ; 122: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 140
	i32 1042160112, ; 123: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 218
	i32 1044663988, ; 124: System.Linq.Expressions.dll => 0x3e444eb4 => 251
	i32 1052210849, ; 125: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 173
	i32 1055189774, ; 126: Shiny.Core.dll => 0x3ee4eb0e => 53
	i32 1061503568, ; 127: Xamarin.Google.AutoValue.Annotations => 0x3f454250 => 221
	i32 1066173877, ; 128: Microsoft.AppCenter => 0x3f8c85b5 => 34
	i32 1084122840, ; 129: Xamarin.Kotlin.StdLib => 0x409e66d8 => 229
	i32 1086034974, ; 130: Syncfusion.DataSource.Portable.dll => 0x40bb941e => 64
	i32 1098167829, ; 131: Xamarin.Android.Arch.Lifecycle.ViewModel => 0x4174b615 => 109
	i32 1098259244, ; 132: System => 0x41761b2c => 93
	i32 1134191450, ; 133: ZXingNetMobile.dll => 0x439a635a => 237
	i32 1141947663, ; 134: Xamarin.Firebase.Measurement.Connector.dll => 0x4410bd0f => 210
	i32 1149092582, ; 135: Xamarin.AndroidX.Window => 0x447dc2e6 => 203
	i32 1175144683, ; 136: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 198
	i32 1176497048, ; 137: eWarranty.resources => 0x461feb98 => 0
	i32 1178241025, ; 138: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 180
	i32 1204270330, ; 139: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 141
	i32 1243150071, ; 140: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 204
	i32 1246548578, ; 141: Xamarin.AndroidX.Collection.Jvm.dll => 0x4a4cd262 => 147
	i32 1264511973, ; 142: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 194
	i32 1264890200, ; 143: Xamarin.KotlinX.Coroutines.Core.dll => 0x4b64b158 => 233
	i32 1267360935, ; 144: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 199
	i32 1275534314, ; 145: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 232
	i32 1278448581, ; 146: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 138
	i32 1292763917, ; 147: Xamarin.Android.Support.CursorAdapter.dll => 0x4d0e030d => 118
	i32 1293217323, ; 148: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 157
	i32 1297413738, ; 149: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0x4d54f66a => 106
	i32 1309284514, ; 150: Plugin.FirebasePushNotification => 0x4e0a18a2 => 47
	i32 1322716291, ; 151: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 203
	i32 1324164729, ; 152: System.Linq => 0x4eed2679 => 247
	i32 1333047053, ; 153: Xamarin.Firebase.Common => 0x4f74af0d => 207
	i32 1365406463, ; 154: System.ServiceModel.Internals.dll => 0x516272ff => 244
	i32 1376866003, ; 155: Xamarin.AndroidX.SavedState => 0x52114ed3 => 190
	i32 1379779777, ; 156: System.Resources.ResourceManager => 0x523dc4c1 => 4
	i32 1393769142, ; 157: eWarranty.Core => 0x53133ab6 => 3
	i32 1395857551, ; 158: Xamarin.AndroidX.Media.dll => 0x5333188f => 177
	i32 1406073936, ; 159: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 151
	i32 1411638395, ; 160: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 98
	i32 1445445088, ; 161: Xamarin.Android.Support.Fragment => 0x5627bde0 => 122
	i32 1452756204, ; 162: Syncfusion.Expander.XForms.Android.dll => 0x56974cec => 65
	i32 1457743152, ; 163: System.Runtime.Extensions.dll => 0x56e36530 => 9
	i32 1460219004, ; 164: Xamarin.Forms.Xaml => 0x57092c7c => 219
	i32 1462112819, ; 165: System.IO.Compression.dll => 0x57261233 => 239
	i32 1469204771, ; 166: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 139
	i32 1470490898, ; 167: Microsoft.Extensions.Primitives => 0x57a5e912 => 41
	i32 1486716862, ; 168: Syncfusion.Cards.XForms => 0x589d7fbe => 61
	i32 1489278563, ; 169: Syncfusion.SfAutoComplete.XForms.dll => 0x58c49663 => 70
	i32 1496693446, ; 170: Syncfusion.SfListView.XForms.Android => 0x5935bac6 => 80
	i32 1516315406, ; 171: Syncfusion.Core.XForms.Android.dll => 0x5a61230e => 62
	i32 1519760047, ; 172: Syncfusion.SfProgressBar.XForms.Android.dll => 0x5a95b2af => 85
	i32 1520711082, ; 173: Syncfusion.SfChart.XForms.Android.dll => 0x5aa435aa => 76
	i32 1524747670, ; 174: Plugin.LocalNotification => 0x5ae1cd96 => 49
	i32 1530663695, ; 175: Xamarin.Forms.Maps.dll => 0x5b3c130f => 214
	i32 1531040989, ; 176: Xamarin.Firebase.Iid.Interop.dll => 0x5b41d4dd => 209
	i32 1533253840, ; 177: Syncfusion.SfBusyIndicator.Android.dll => 0x5b6398d0 => 71
	i32 1543031311, ; 178: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 252
	i32 1550322496, ; 179: System.Reflection.Extensions.dll => 0x5c680b40 => 10
	i32 1566488712, ; 180: Syncfusion.SfBusyIndicator.XForms.dll => 0x5d5eb888 => 73
	i32 1574652163, ; 181: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 117
	i32 1582372066, ; 182: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 156
	i32 1587447679, ; 183: Xamarin.Android.Arch.Core.Common.dll => 0x5e9e877f => 103
	i32 1592978981, ; 184: System.Runtime.Serialization.dll => 0x5ef2ee25 => 18
	i32 1622152042, ; 185: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 175
	i32 1622358360, ; 186: System.Dynamic.Runtime => 0x60b33958 => 250
	i32 1624863272, ; 187: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 202
	i32 1634619362, ; 188: Xamarin.AndroidX.Room.Common => 0x616e4fe2 => 187
	i32 1635184631, ; 189: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 160
	i32 1636350590, ; 190: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 154
	i32 1637556708, ; 191: Syncfusion.SfProgressBar.XForms.dll => 0x619b21e4 => 86
	i32 1639515021, ; 192: System.Net.Http.dll => 0x61b9038d => 94
	i32 1639986890, ; 193: System.Text.RegularExpressions => 0x61c036ca => 252
	i32 1653276212, ; 194: Microsoft.AppCenter.Android.Bindings => 0x628afe34 => 31
	i32 1657153582, ; 195: System.Runtime => 0x62c6282e => 99
	i32 1658241508, ; 196: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 196
	i32 1658251792, ; 197: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 220
	i32 1662014763, ; 198: Xamarin.Android.Support.Vector.Drawable => 0x6310552b => 132
	i32 1670060433, ; 199: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 150
	i32 1701541528, ; 200: System.Diagnostics.Debug.dll => 0x656b7698 => 7
	i32 1712766919, ; 201: Syncfusion.SfComboBox.XForms.dll => 0x6616bfc7 => 79
	i32 1720223769, ; 202: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 168
	i32 1726116996, ; 203: System.Reflection.dll => 0x66e27484 => 6
	i32 1729485958, ; 204: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 145
	i32 1736948048, ; 205: Xamarin.AndroidX.Sqlite.dll => 0x6787b950 => 192
	i32 1758026047, ; 206: Xamarin.AndroidX.Room.Runtime.dll => 0x68c9593f => 189
	i32 1765942094, ; 207: System.Reflection.Extensions => 0x6942234e => 10
	i32 1766324549, ; 208: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 195
	i32 1770582343, ; 209: Microsoft.Extensions.Logging.dll => 0x6988f147 => 39
	i32 1776026572, ; 210: System.Core.dll => 0x69dc03cc => 91
	i32 1788241197, ; 211: Xamarin.AndroidX.Fragment => 0x6a96652d => 161
	i32 1808609942, ; 212: Xamarin.AndroidX.Loader => 0x6bcd3296 => 175
	i32 1813058853, ; 213: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 229
	i32 1813201214, ; 214: Xamarin.Google.Android.Material => 0x6c13413e => 220
	i32 1818569960, ; 215: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 181
	i32 1828688058, ; 216: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 38
	i32 1858542181, ; 217: System.Linq.Expressions => 0x6ec71a65 => 251
	i32 1866717392, ; 218: Xamarin.Android.Support.Interpolator.dll => 0x6f43d8d0 => 123
	i32 1867746548, ; 219: Xamarin.Essentials.dll => 0x6f538cf4 => 206
	i32 1878053835, ; 220: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 219
	i32 1881744805, ; 221: Shiny.Notifications.dll => 0x702925a5 => 54
	i32 1881862856, ; 222: Xamarin.Forms.Maps.Android.dll => 0x702af2c8 => 213
	i32 1885316902, ; 223: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 142
	i32 1898262354, ; 224: dotMorten.Xamarin.Forms.AutoSuggestBox.dll => 0x71252f52 => 21
	i32 1900610850, ; 225: System.Resources.ResourceManager.dll => 0x71490522 => 4
	i32 1904184254, ; 226: FastAndroidCamera => 0x717f8bbe => 23
	i32 1904755420, ; 227: System.Runtime.InteropServices.WindowsRuntime.dll => 0x718842dc => 17
	i32 1908813208, ; 228: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 224
	i32 1916660109, ; 229: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x723de98d => 109
	i32 1919157823, ; 230: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 178
	i32 1923463307, ; 231: eWarranty => 0x72a5b88b => 22
	i32 1933215285, ; 232: Xamarin.Firebase.Messaging.dll => 0x733a8635 => 211
	i32 1936121326, ; 233: Syncfusion.SfPicker.XForms.dll => 0x7366ddee => 84
	i32 1969191170, ; 234: Syncfusion.SfCarousel.XForms.dll => 0x755f7902 => 75
	i32 1991544456, ; 235: SignaturePad.Forms.dll => 0x76b48e88 => 56
	i32 2011961780, ; 236: System.Buffers.dll => 0x77ec19b4 => 90
	i32 2019465201, ; 237: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 173
	i32 2024078044, ; 238: Microsoft.AppCenter.Analytics.dll => 0x78a4fadc => 30
	i32 2036898326, ; 239: Plugin.Iconize.dll => 0x79689a16 => 48
	i32 2037417872, ; 240: Xamarin.Android.Support.ViewPager => 0x79708790 => 134
	i32 2044222327, ; 241: Xamarin.Android.Support.Loader => 0x79d85b77 => 124
	i32 2045425888, ; 242: Microsoft.AppCenter.Analytics.Android.Bindings => 0x79eab8e0 => 29
	i32 2055257422, ; 243: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 167
	i32 2071563619, ; 244: Syncfusion.Buttons.XForms.Android => 0x7b798d63 => 58
	i32 2079627543, ; 245: Plugin.Multilingual.dll => 0x7bf49917 => 51
	i32 2079903147, ; 246: System.Runtime.dll => 0x7bf8cdab => 99
	i32 2090596640, ; 247: System.Numerics.Vectors => 0x7c9bf920 => 96
	i32 2097448633, ; 248: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 163
	i32 2113902067, ; 249: Xamarin.Forms.PancakeView.dll => 0x7dff95f3 => 216
	i32 2126786730, ; 250: Xamarin.Forms.Platform.Android => 0x7ec430aa => 217
	i32 2129483829, ; 251: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 223
	i32 2133113917, ; 252: Syncfusion.SfChart.XForms => 0x7f24bc3d => 77
	i32 2139458754, ; 253: Xamarin.Android.Support.DrawerLayout => 0x7f858cc2 => 121
	i32 2166116741, ; 254: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 117
	i32 2174120593, ; 255: Syncfusion.SfRadialMenu.XForms.Android => 0x81967291 => 88
	i32 2181898931, ; 256: Microsoft.Extensions.Options.dll => 0x820d22b3 => 40
	i32 2192057212, ; 257: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 38
	i32 2193016926, ; 258: System.ObjectModel.dll => 0x82b6c85e => 245
	i32 2196165013, ; 259: Xamarin.Android.Support.VersionedParcelable => 0x82e6d195 => 133
	i32 2201107256, ; 260: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 234
	i32 2201231467, ; 261: System.Net.Http => 0x8334206b => 94
	i32 2217644978, ; 262: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 198
	i32 2244775296, ; 263: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 176
	i32 2256548716, ; 264: Xamarin.AndroidX.MultiDex => 0x8680336c => 178
	i32 2261435625, ; 265: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 165
	i32 2272153315, ; 266: Syncfusion.SfPicker.Android.dll => 0x876e4ee3 => 82
	i32 2279703579, ; 267: Xamarin.AndroidX.Sqlite.Framework.dll => 0x87e1841b => 193
	i32 2279755925, ; 268: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 185
	i32 2292652185, ; 269: Syncfusion.SfRadialMenu.Android.dll => 0x88a71899 => 87
	i32 2315684594, ; 270: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 136
	i32 2330457430, ; 271: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 116
	i32 2330986192, ; 272: Xamarin.Android.Support.SlidingPaneLayout.dll => 0x8af006d0 => 128
	i32 2341995103, ; 273: ZXingNetMobile => 0x8b98025f => 237
	i32 2343171156, ; 274: Syncfusion.Core.XForms => 0x8ba9f454 => 63
	i32 2354730003, ; 275: Syncfusion.Licensing => 0x8c5a5413 => 68
	i32 2373288475, ; 276: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 122
	i32 2397082276, ; 277: Xamarin.Forms.PancakeView => 0x8ee092a4 => 216
	i32 2403452196, ; 278: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 159
	i32 2409053734, ; 279: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 182
	i32 2440966767, ; 280: Xamarin.Android.Support.Loader.dll => 0x917e326f => 124
	i32 2454642406, ; 281: System.Text.Encoding.dll => 0x924edee6 => 11
	i32 2465532216, ; 282: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 149
	i32 2471215200, ; 283: ImageCircle.Forms.Plugin => 0x934bc060 => 25
	i32 2471841756, ; 284: netstandard.dll => 0x93554fdc => 2
	i32 2475788418, ; 285: Java.Interop.dll => 0x93918882 => 26
	i32 2483661569, ; 286: Xamarin.Firebase.Measurement.Connector => 0x9409ab01 => 210
	i32 2483742551, ; 287: Xamarin.Firebase.Messaging => 0x940ae757 => 211
	i32 2487632829, ; 288: Xamarin.Android.Support.DocumentFile => 0x944643bd => 120
	i32 2490993605, ; 289: System.AppContext.dll => 0x94798bc5 => 255
	i32 2501346920, ; 290: System.Data.DataSetExtensions => 0x95178668 => 238
	i32 2505896520, ; 291: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 171
	i32 2508407795, ; 292: Syncfusion.SfCarousel.XForms.Android.dll => 0x958343f3 => 74
	i32 2515096885, ; 293: Syncfusion.DataSource.Portable => 0x95e95535 => 64
	i32 2562349572, ; 294: Microsoft.CSharp => 0x98ba5a04 => 35
	i32 2563143864, ; 295: AndHUD.dll => 0x98c678b8 => 19
	i32 2576000824, ; 296: eWarranty.resources.dll => 0x998aa738 => 0
	i32 2581819634, ; 297: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 199
	i32 2605712449, ; 298: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 234
	i32 2620871830, ; 299: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 154
	i32 2624644809, ; 300: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 158
	i32 2624721879, ; 301: Syncfusion.SfChart.XForms.Android => 0x9c7213d7 => 76
	i32 2633051222, ; 302: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 169
	i32 2635217119, ; 303: Syncfusion.SfAutoComplete.XForms.Android => 0x9d1238df => 69
	i32 2635300604, ; 304: Syncfusion.Buttons.XForms => 0x9d137efc => 59
	i32 2647358571, ; 305: Syncfusion.SfAutoComplete.XForms.Android.dll => 0x9dcb7c6b => 69
	i32 2671474046, ; 306: Xamarin.KotlinX.Coroutines.Core => 0x9f3b757e => 233
	i32 2691104573, ; 307: Xamarin.AndroidX.Room.Room.Ktx.dll => 0xa066ff3d => 188
	i32 2697269578, ; 308: Microsoft.AppCenter.Crashes.dll => 0xa0c5114a => 33
	i32 2698266930, ; 309: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa0d44932 => 107
	i32 2701096212, ; 310: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 196
	i32 2715334215, ; 311: System.Threading.Tasks.dll => 0xa1d8b647 => 246
	i32 2732626843, ; 312: Xamarin.AndroidX.Activity => 0xa2e0939b => 135
	i32 2737747696, ; 313: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 139
	i32 2739926663, ; 314: Xamarin.AndroidX.Sqlite.Framework => 0xa34ff687 => 193
	i32 2751899777, ; 315: Xamarin.Android.Support.Collections => 0xa406a881 => 113
	i32 2766581644, ; 316: Xamarin.Forms.Core => 0xa4e6af8c => 212
	i32 2770495804, ; 317: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 228
	i32 2778768386, ; 318: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 201
	i32 2779977773, ; 319: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 186
	i32 2784016111, ; 320: Syncfusion.SfPicker.XForms => 0xa5f0b6ef => 84
	i32 2788639665, ; 321: Xamarin.Android.Support.LocalBroadcastManager => 0xa63743b1 => 125
	i32 2788775637, ; 322: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0xa63956d5 => 129
	i32 2806986428, ; 323: Plugin.CurrentActivity.dll => 0xa74f36bc => 46
	i32 2810250172, ; 324: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 151
	i32 2819470561, ; 325: System.Xml.dll => 0xa80db4e1 => 100
	i32 2821294376, ; 326: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 186
	i32 2843355708, ; 327: Lottie.Android.dll => 0xa97a2a3c => 27
	i32 2847418871, ; 328: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 223
	i32 2849962309, ; 329: Microsoft.AppCenter.Android.Bindings.dll => 0xa9def945 => 31
	i32 2853208004, ; 330: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 201
	i32 2854891590, ; 331: Syncfusion.SfProgressBar.XForms => 0xaa2a3046 => 86
	i32 2855708567, ; 332: Xamarin.AndroidX.Transition => 0xaa36a797 => 197
	i32 2861816565, ; 333: Rg.Plugins.Popup.dll => 0xaa93daf5 => 52
	i32 2868557005, ; 334: Syncfusion.Licensing.dll => 0xaafab4cd => 68
	i32 2870995654, ; 335: Xamarin.Firebase.Iid => 0xab1feac6 => 208
	i32 2874148507, ; 336: Syncfusion.Core.XForms.Android => 0xab50069b => 62
	i32 2876493027, ; 337: Xamarin.Android.Support.SwipeRefreshLayout => 0xab73cce3 => 129
	i32 2886109683, ; 338: Syncfusion.SfBusyIndicator.XForms.Android.dll => 0xac0689f3 => 72
	i32 2893257763, ; 339: Xamarin.Android.Arch.Core.Runtime.dll => 0xac739c23 => 104
	i32 2900621748, ; 340: System.Dynamic.Runtime.dll => 0xace3f9b4 => 250
	i32 2901442782, ; 341: System.Reflection => 0xacf080de => 6
	i32 2903344695, ; 342: System.ComponentModel.Composition => 0xad0d8637 => 241
	i32 2905242038, ; 343: mscorlib.dll => 0xad2a79b6 => 44
	i32 2914202368, ; 344: Xamarin.Firebase.Iid.Interop => 0xadb33300 => 209
	i32 2916838712, ; 345: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 202
	i32 2919462931, ; 346: System.Numerics.Vectors.dll => 0xae037813 => 96
	i32 2921128767, ; 347: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 137
	i32 2921692953, ; 348: Xamarin.Android.Support.CustomView.dll => 0xae257f19 => 119
	i32 2922925221, ; 349: Xamarin.Android.Support.Vector.Drawable.dll => 0xae384ca5 => 132
	i32 2943219317, ; 350: Square.OkIO => 0xaf6df675 => 57
	i32 2953735189, ; 351: Xamarin.AndroidX.Lifecycle.Service.dll => 0xb00e6c15 => 172
	i32 2959614098, ; 352: System.ComponentModel.dll => 0xb0682092 => 13
	i32 2978675010, ; 353: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 157
	i32 2986342291, ; 354: Xamanimation => 0xb1fff793 => 102
	i32 2987479406, ; 355: eWarranty.Android => 0xb211516e => 1
	i32 2996846495, ; 356: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 170
	i32 3016983068, ; 357: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 194
	i32 3017076677, ; 358: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 225
	i32 3024354802, ; 359: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 164
	i32 3033570130, ; 360: dotMorten.Xamarin.Forms.AutoSuggestBox => 0xb4d09b52 => 21
	i32 3037436946, ; 361: Microsoft.AppCenter.Analytics.Android.Bindings.dll => 0xb50b9c12 => 29
	i32 3044182254, ; 362: FormsViewGroup => 0xb57288ee => 24
	i32 3056250942, ; 363: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0xb62ab03e => 112
	i32 3057625584, ; 364: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 179
	i32 3058099980, ; 365: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 227
	i32 3068715062, ; 366: Xamarin.Android.Arch.Lifecycle.Common => 0xb6e8e036 => 105
	i32 3071899978, ; 367: Xamarin.Firebase.Common.dll => 0xb719794a => 207
	i32 3075834255, ; 368: System.Threading.Tasks => 0xb755818f => 246
	i32 3092211740, ; 369: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 126
	i32 3104361006, ; 370: DLToolkit.Forms.Controls.FlowListView.dll => 0xb908ca2e => 20
	i32 3111772706, ; 371: System.Runtime.Serialization => 0xb979e222 => 18
	i32 3124832203, ; 372: System.Threading.Tasks.Extensions => 0xba4127cb => 257
	i32 3144132135, ; 373: Xamarin.AndroidX.Sqlite => 0xbb67a627 => 192
	i32 3147165239, ; 374: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 253
	i32 3196832649, ; 375: Plugin.Multilingual => 0xbe8bcb89 => 51
	i32 3204380047, ; 376: System.Data.dll => 0xbefef58f => 15
	i32 3204912593, ; 377: Xamarin.Android.Support.AsyncLayoutInflater => 0xbf0715d1 => 112
	i32 3211777861, ; 378: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 156
	i32 3215347189, ; 379: zxing => 0xbfa64df5 => 236
	i32 3220365878, ; 380: System.Threading => 0xbff2e236 => 8
	i32 3223546065, ; 381: Syncfusion.Expander.XForms => 0xc02368d1 => 66
	i32 3230466174, ; 382: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 224
	i32 3233339011, ; 383: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xc0b8d683 => 106
	i32 3247949154, ; 384: Mono.Security => 0xc197c562 => 256
	i32 3258312781, ; 385: Xamarin.AndroidX.CardView => 0xc235e84d => 145
	i32 3263631797, ; 386: Lottie.Forms => 0xc28711b5 => 28
	i32 3264650703, ; 387: XF.Material => 0xc2969dcf => 235
	i32 3265493905, ; 388: System.Linq.Queryable.dll => 0xc2a37b91 => 14
	i32 3265893370, ; 389: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 257
	i32 3267021929, ; 390: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 143
	i32 3270722617, ; 391: Syncfusion.SfPicker.Android => 0xc2f34439 => 82
	i32 3296380511, ; 392: Xamarin.Android.Support.Collections.dll => 0xc47ac65f => 113
	i32 3299363146, ; 393: System.Text.Encoding => 0xc4a8494a => 11
	i32 3317135071, ; 394: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 155
	i32 3317144872, ; 395: System.Data => 0xc5b79d28 => 15
	i32 3321585405, ; 396: Xamarin.Android.Support.DocumentFile.dll => 0xc5fb5efd => 120
	i32 3331531814, ; 397: Xamarin.GooglePlayServices.Stats.dll => 0xc6932426 => 226
	i32 3340431453, ; 398: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 142
	i32 3345895724, ; 399: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 184
	i32 3346324047, ; 400: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 180
	i32 3352662376, ; 401: Xamarin.Android.Support.CoordinaterLayout => 0xc7d59168 => 115
	i32 3353484488, ; 402: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 163
	i32 3357663996, ; 403: Xamarin.Android.Support.CursorAdapter => 0xc821e2fc => 118
	i32 3362522851, ; 404: Xamarin.AndroidX.Core => 0xc86c06e3 => 153
	i32 3366347497, ; 405: Java.Interop => 0xc8a662e9 => 26
	i32 3369296695, ; 406: Syncfusion.SfRadialMenu.XForms => 0xc8d36337 => 89
	i32 3374999561, ; 407: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 185
	i32 3395150330, ; 408: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 98
	i32 3401559547, ; 409: Plugin.FirebasePushNotification.dll => 0xcabfadfb => 47
	i32 3404865022, ; 410: System.ServiceModel.Internals => 0xcaf21dfe => 244
	i32 3428513518, ; 411: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 37
	i32 3429136800, ; 412: System.Xml => 0xcc6479a0 => 100
	i32 3430777524, ; 413: netstandard => 0xcc7d82b4 => 2
	i32 3434749838, ; 414: Syncfusion.Buttons.XForms.Android.dll => 0xccba1f8e => 58
	i32 3439690031, ; 415: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 111
	i32 3441283291, ; 416: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 158
	i32 3442543374, ; 417: AndHUD => 0xcd310b0e => 19
	i32 3448958507, ; 418: Syncfusion.GridCommon.Portable.dll => 0xcd92ee2b => 67
	i32 3460255358, ; 419: Syncfusion.SfBusyIndicator.XForms => 0xce3f4e7e => 73
	i32 3476120550, ; 420: Mono.Android => 0xcf3163e6 => 42
	i32 3483112796, ; 421: ImageCircle.Forms.Plugin.dll => 0xcf9c155c => 25
	i32 3486566296, ; 422: System.Transactions => 0xcfd0c798 => 242
	i32 3493954962, ; 423: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 148
	i32 3499824017, ; 424: Syncfusion.Expander.XForms.dll => 0xd09b1391 => 66
	i32 3501239056, ; 425: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 143
	i32 3509114376, ; 426: System.Xml.Linq => 0xd128d608 => 101
	i32 3536029504, ; 427: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 217
	i32 3544322670, ; 428: Syncfusion.SfProgressBar.XForms.Android => 0xd342126e => 85
	i32 3547625832, ; 429: Xamarin.Android.Support.SlidingPaneLayout => 0xd3747968 => 128
	i32 3567349600, ; 430: System.ComponentModel.Composition.dll => 0xd4a16f60 => 241
	i32 3573036112, ; 431: Xamarin.AndroidX.Room.Room.Ktx => 0xd4f83450 => 188
	i32 3608519521, ; 432: System.Linq.dll => 0xd715a361 => 247
	i32 3612947231, ; 433: Xamarin.AndroidX.Work.Runtime => 0xd759331f => 205
	i32 3618140916, ; 434: Xamarin.AndroidX.Preference => 0xd7a872f4 => 182
	i32 3627220390, ; 435: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 183
	i32 3632266177, ; 436: Syncfusion.SfComboBox.XForms => 0xd87ffbc1 => 79
	i32 3632359727, ; 437: Xamarin.Forms.Platform => 0xd881692f => 218
	i32 3633644679, ; 438: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 137
	i32 3639449509, ; 439: Lottie.Android => 0xd8ed97a5 => 27
	i32 3641597786, ; 440: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 167
	i32 3664423555, ; 441: Xamarin.Android.Support.ViewPager.dll => 0xda6aaa83 => 134
	i32 3672681054, ; 442: Mono.Android.dll => 0xdae8aa5e => 42
	i32 3676310014, ; 443: System.Web.Services.dll => 0xdb2009fe => 243
	i32 3678221644, ; 444: Xamarin.Android.Support.v7.AppCompat => 0xdb3d354c => 131
	i32 3681174138, ; 445: Xamarin.Android.Arch.Lifecycle.Common.dll => 0xdb6a427a => 105
	i32 3682565725, ; 446: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 144
	i32 3684561358, ; 447: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 148
	i32 3684933406, ; 448: System.Runtime.InteropServices.WindowsRuntime => 0xdba39f1e => 17
	i32 3685813676, ; 449: Xamarin.Forms.Material.dll => 0xdbb10dac => 215
	i32 3689375977, ; 450: System.Drawing.Common => 0xdbe768e9 => 12
	i32 3706696989, ; 451: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 152
	i32 3714038699, ; 452: Xamarin.Android.Support.LocalBroadcastManager.dll => 0xdd5fbbab => 125
	i32 3718463572, ; 453: Xamarin.Android.Support.Animated.Vector.Drawable.dll => 0xdda34054 => 110
	i32 3718780102, ; 454: Xamarin.AndroidX.Annotation => 0xdda814c6 => 136
	i32 3724971120, ; 455: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 179
	i32 3731644420, ; 456: System.Reactive => 0xde6c6004 => 97
	i32 3735092365, ; 457: Xamarin.AndroidX.Room.Common.dll => 0xdea0fc8d => 187
	i32 3736173093, ; 458: MR.Gestures.dll => 0xdeb17a25 => 43
	i32 3748608112, ; 459: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 92
	i32 3754700086, ; 460: Plugin.Multilingual.Abstractions.dll => 0xdfcc2d36 => 50
	i32 3758932259, ; 461: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 165
	i32 3759042612, ; 462: Syncfusion.SfCarousel.XForms => 0xe00e7034 => 75
	i32 3776062606, ; 463: Xamarin.Android.Support.DrawerLayout.dll => 0xe112248e => 121
	i32 3786282454, ; 464: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 146
	i32 3822602673, ; 465: Xamarin.AndroidX.Media => 0xe3d849b1 => 177
	i32 3829621856, ; 466: System.Numerics.dll => 0xe4436460 => 95
	i32 3832731800, ; 467: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe472d898 => 115
	i32 3837938240, ; 468: Syncfusion.SfListView.XForms.Android.dll => 0xe4c24a40 => 80
	i32 3841636137, ; 469: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 36
	i32 3849253459, ; 470: System.Runtime.InteropServices.dll => 0xe56ef253 => 254
	i32 3862817207, ; 471: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0xe63de9b7 => 108
	i32 3866512743, ; 472: Syncfusion.SfRadialMenu.XForms.dll => 0xe6764d67 => 89
	i32 3869245228, ; 473: Microsoft.AppCenter.Crashes.Android.Bindings.dll => 0xe69fff2c => 32
	i32 3874897629, ; 474: Xamarin.Android.Arch.Lifecycle.Runtime => 0xe6f63edd => 108
	i32 3883175360, ; 475: Xamarin.Android.Support.v7.AppCompat.dll => 0xe7748dc0 => 131
	i32 3885922214, ; 476: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 197
	i32 3888767677, ; 477: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 184
	i32 3896106733, ; 478: System.Collections.Concurrent.dll => 0xe839deed => 16
	i32 3896760992, ; 479: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 153
	i32 3910130544, ; 480: Xamarin.AndroidX.Collection.Jvm => 0xe90fdb70 => 147
	i32 3920810846, ; 481: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 240
	i32 3921031405, ; 482: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 200
	i32 3929079551, ; 483: Syncfusion.Cards.XForms.Android.dll => 0xea30feff => 60
	i32 3931092270, ; 484: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 181
	i32 3945713374, ; 485: System.Data.DataSetExtensions.dll => 0xeb2ecede => 238
	i32 3949143839, ; 486: Syncfusion.SfPicker.XForms.Android.dll => 0xeb63271f => 83
	i32 3955647286, ; 487: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 140
	i32 3959773229, ; 488: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 170
	i32 3965022950, ; 489: Syncfusion.SfComboBox.XForms.Android.dll => 0xec5572e6 => 78
	i32 3970018735, ; 490: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 227
	i32 4004095362, ; 491: Syncfusion.Expander.XForms.Android => 0xeea9a582 => 65
	i32 4015948917, ; 492: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 138
	i32 4025784931, ; 493: System.Memory => 0xeff49a63 => 248
	i32 4047670059, ; 494: Xamanimation.dll => 0xf1428b2b => 102
	i32 4051712506, ; 495: Syncfusion.GridCommon.Portable => 0xf18039fa => 67
	i32 4063435586, ; 496: Xamarin.Android.Support.CustomView => 0xf2331b42 => 119
	i32 4071430779, ; 497: SignaturePad.Forms => 0xf2ad1a7b => 56
	i32 4073602200, ; 498: System.Threading.dll => 0xf2ce3c98 => 8
	i32 4078019152, ; 499: Plugin.Iconize => 0xf311a250 => 48
	i32 4101593132, ; 500: Xamarin.AndroidX.Emoji2 => 0xf479582c => 159
	i32 4105002889, ; 501: Mono.Security.dll => 0xf4ad5f89 => 256
	i32 4126470640, ; 502: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 37
	i32 4130442656, ; 503: System.AppContext => 0xf6318da0 => 255
	i32 4137181845, ; 504: Xamarin.AndroidX.Room.Runtime => 0xf6986295 => 189
	i32 4146307099, ; 505: Microsoft.AppCenter.Crashes => 0xf723a01b => 33
	i32 4151237749, ; 506: System.Core => 0xf76edc75 => 91
	i32 4182413190, ; 507: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 174
	i32 4213026141, ; 508: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 92
	i32 4234640426, ; 509: eWarranty.dll => 0xfc677c2a => 22
	i32 4256097574, ; 510: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 152
	i32 4260525087, ; 511: System.Buffers => 0xfdf2741f => 90
	i32 4264222770, ; 512: eWarranty.Core.dll => 0xfe2ae032 => 3
	i32 4278134329, ; 513: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 225
	i32 4287798392, ; 514: Shiny.Notifications => 0xff929c78 => 54
	i32 4292120959 ; 515: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 174
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [516 x i32] [
	i32 60, i32 87, i32 171, i32 222, i32 45, i32 212, i32 133, i32 59, ; 0..7
	i32 208, i32 191, i32 235, i32 254, i32 191, i32 230, i32 28, i32 103, ; 8..15
	i32 146, i32 114, i32 23, i32 195, i32 104, i32 13, i32 144, i32 213, ; 16..23
	i32 130, i32 7, i32 164, i32 35, i32 249, i32 243, i32 150, i32 169, ; 24..31
	i32 162, i32 77, i32 205, i32 135, i32 214, i32 95, i32 72, i32 166, ; 32..39
	i32 70, i32 215, i32 248, i32 110, i32 116, i32 149, i32 206, i32 5, ; 40..47
	i32 161, i32 44, i32 93, i32 162, i32 176, i32 245, i32 49, i32 1, ; 48..55
	i32 41, i32 114, i32 127, i32 242, i32 230, i32 14, i32 81, i32 71, ; 56..63
	i32 39, i32 226, i32 9, i32 83, i32 204, i32 240, i32 97, i32 155, ; 64..71
	i32 160, i32 200, i32 141, i32 16, i32 101, i32 232, i32 111, i32 81, ; 72..79
	i32 228, i32 61, i32 63, i32 231, i32 34, i32 78, i32 53, i32 239, ; 80..87
	i32 221, i32 40, i32 20, i32 123, i32 55, i32 168, i32 12, i32 172, ; 88..95
	i32 183, i32 236, i32 249, i32 130, i32 32, i32 52, i32 55, i32 127, ; 96..103
	i32 50, i32 222, i32 43, i32 88, i32 45, i32 231, i32 46, i32 126, ; 104..111
	i32 57, i32 166, i32 24, i32 253, i32 107, i32 5, i32 74, i32 190, ; 112..119
	i32 36, i32 30, i32 140, i32 218, i32 251, i32 173, i32 53, i32 221, ; 120..127
	i32 34, i32 229, i32 64, i32 109, i32 93, i32 237, i32 210, i32 203, ; 128..135
	i32 198, i32 0, i32 180, i32 141, i32 204, i32 147, i32 194, i32 233, ; 136..143
	i32 199, i32 232, i32 138, i32 118, i32 157, i32 106, i32 47, i32 203, ; 144..151
	i32 247, i32 207, i32 244, i32 190, i32 4, i32 3, i32 177, i32 151, ; 152..159
	i32 98, i32 122, i32 65, i32 9, i32 219, i32 239, i32 139, i32 41, ; 160..167
	i32 61, i32 70, i32 80, i32 62, i32 85, i32 76, i32 49, i32 214, ; 168..175
	i32 209, i32 71, i32 252, i32 10, i32 73, i32 117, i32 156, i32 103, ; 176..183
	i32 18, i32 175, i32 250, i32 202, i32 187, i32 160, i32 154, i32 86, ; 184..191
	i32 94, i32 252, i32 31, i32 99, i32 196, i32 220, i32 132, i32 150, ; 192..199
	i32 7, i32 79, i32 168, i32 6, i32 145, i32 192, i32 189, i32 10, ; 200..207
	i32 195, i32 39, i32 91, i32 161, i32 175, i32 229, i32 220, i32 181, ; 208..215
	i32 38, i32 251, i32 123, i32 206, i32 219, i32 54, i32 213, i32 142, ; 216..223
	i32 21, i32 4, i32 23, i32 17, i32 224, i32 109, i32 178, i32 22, ; 224..231
	i32 211, i32 84, i32 75, i32 56, i32 90, i32 173, i32 30, i32 48, ; 232..239
	i32 134, i32 124, i32 29, i32 167, i32 58, i32 51, i32 99, i32 96, ; 240..247
	i32 163, i32 216, i32 217, i32 223, i32 77, i32 121, i32 117, i32 88, ; 248..255
	i32 40, i32 38, i32 245, i32 133, i32 234, i32 94, i32 198, i32 176, ; 256..263
	i32 178, i32 165, i32 82, i32 193, i32 185, i32 87, i32 136, i32 116, ; 264..271
	i32 128, i32 237, i32 63, i32 68, i32 122, i32 216, i32 159, i32 182, ; 272..279
	i32 124, i32 11, i32 149, i32 25, i32 2, i32 26, i32 210, i32 211, ; 280..287
	i32 120, i32 255, i32 238, i32 171, i32 74, i32 64, i32 35, i32 19, ; 288..295
	i32 0, i32 199, i32 234, i32 154, i32 158, i32 76, i32 169, i32 69, ; 296..303
	i32 59, i32 69, i32 233, i32 188, i32 33, i32 107, i32 196, i32 246, ; 304..311
	i32 135, i32 139, i32 193, i32 113, i32 212, i32 228, i32 201, i32 186, ; 312..319
	i32 84, i32 125, i32 129, i32 46, i32 151, i32 100, i32 186, i32 27, ; 320..327
	i32 223, i32 31, i32 201, i32 86, i32 197, i32 52, i32 68, i32 208, ; 328..335
	i32 62, i32 129, i32 72, i32 104, i32 250, i32 6, i32 241, i32 44, ; 336..343
	i32 209, i32 202, i32 96, i32 137, i32 119, i32 132, i32 57, i32 172, ; 344..351
	i32 13, i32 157, i32 102, i32 1, i32 170, i32 194, i32 225, i32 164, ; 352..359
	i32 21, i32 29, i32 24, i32 112, i32 179, i32 227, i32 105, i32 207, ; 360..367
	i32 246, i32 126, i32 20, i32 18, i32 257, i32 192, i32 253, i32 51, ; 368..375
	i32 15, i32 112, i32 156, i32 236, i32 8, i32 66, i32 224, i32 106, ; 376..383
	i32 256, i32 145, i32 28, i32 235, i32 14, i32 257, i32 143, i32 82, ; 384..391
	i32 113, i32 11, i32 155, i32 15, i32 120, i32 226, i32 142, i32 184, ; 392..399
	i32 180, i32 115, i32 163, i32 118, i32 153, i32 26, i32 89, i32 185, ; 400..407
	i32 98, i32 47, i32 244, i32 37, i32 100, i32 2, i32 58, i32 111, ; 408..415
	i32 158, i32 19, i32 67, i32 73, i32 42, i32 25, i32 242, i32 148, ; 416..423
	i32 66, i32 143, i32 101, i32 217, i32 85, i32 128, i32 241, i32 188, ; 424..431
	i32 247, i32 205, i32 182, i32 183, i32 79, i32 218, i32 137, i32 27, ; 432..439
	i32 167, i32 134, i32 42, i32 243, i32 131, i32 105, i32 144, i32 148, ; 440..447
	i32 17, i32 215, i32 12, i32 152, i32 125, i32 110, i32 136, i32 179, ; 448..455
	i32 97, i32 187, i32 43, i32 92, i32 50, i32 165, i32 75, i32 121, ; 456..463
	i32 146, i32 177, i32 95, i32 115, i32 80, i32 36, i32 254, i32 108, ; 464..471
	i32 89, i32 32, i32 108, i32 131, i32 197, i32 184, i32 16, i32 153, ; 472..479
	i32 147, i32 240, i32 200, i32 60, i32 181, i32 238, i32 83, i32 140, ; 480..487
	i32 170, i32 78, i32 227, i32 65, i32 138, i32 248, i32 102, i32 67, ; 488..495
	i32 119, i32 56, i32 8, i32 48, i32 159, i32 256, i32 37, i32 255, ; 496..503
	i32 189, i32 33, i32 91, i32 174, i32 92, i32 22, i32 152, i32 90, ; 504..511
	i32 3, i32 225, i32 54, i32 174 ; 512..515
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
