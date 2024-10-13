; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [150 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [300 x i32] [
	i32 38948123, ; 0: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 1
	i32 39109920, ; 1: Newtonsoft.Json.dll => 0x254c520 => 52
	i32 42244203, ; 2: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 10
	i32 42639949, ; 3: System.Threading.Thread => 0x28aa24d => 138
	i32 67008169, ; 4: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 34
	i32 72070932, ; 5: Microsoft.Maui.Graphics.dll => 0x44bb714 => 51
	i32 83839681, ; 6: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 18
	i32 117431740, ; 7: System.Runtime.InteropServices => 0x6ffddbc => 127
	i32 118323712, ; 8: Namada Maui.dll => 0x70d7a00 => 92
	i32 136584136, ; 9: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 33
	i32 140062828, ; 10: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 26
	i32 165246403, ; 11: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 64
	i32 182336117, ; 12: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 82
	i32 205061960, ; 13: System.ComponentModel => 0xc38ff48 => 101
	i32 209399409, ; 14: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 62
	i32 230752869, ; 15: Microsoft.CSharp.dll => 0xdc10265 => 93
	i32 246610117, ; 16: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 124
	i32 317674968, ; 17: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 31
	i32 318968648, ; 18: Xamarin.AndroidX.Activity.dll => 0x13031348 => 59
	i32 321963286, ; 19: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 9
	i32 342366114, ; 20: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 71
	i32 347068432, ; 21: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 57
	i32 379916513, ; 22: System.Threading.Thread.dll => 0x16a510e1 => 138
	i32 385762202, ; 23: System.Memory.dll => 0x16fe439a => 113
	i32 395744057, ; 24: _Microsoft.Android.Resource.Designer => 0x17969339 => 35
	i32 409257351, ; 25: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 29
	i32 410463064, ; 26: Namada Maui.resources => 0x18772b58 => 0
	i32 442565967, ; 27: System.Collections => 0x1a61054f => 98
	i32 450948140, ; 28: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 70
	i32 456227837, ; 29: System.Web.HttpUtility.dll => 0x1b317bfd => 140
	i32 459347974, ; 30: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 131
	i32 469710990, ; 31: System.dll => 0x1bff388e => 144
	i32 489220957, ; 32: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 7
	i32 498788369, ; 33: System.ObjectModel => 0x1dbae811 => 119
	i32 504143952, ; 34: Plugin.LocalNotification.dll => 0x1e0ca050 => 53
	i32 513247710, ; 35: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 45
	i32 538707440, ; 36: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 28
	i32 539058512, ; 37: Microsoft.Extensions.Logging => 0x20216150 => 42
	i32 597488923, ; 38: CommunityToolkit.Maui => 0x239cf51b => 36
	i32 627609679, ; 39: Xamarin.AndroidX.CustomView => 0x2568904f => 68
	i32 627931235, ; 40: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 20
	i32 662205335, ; 41: System.Text.Encodings.Web.dll => 0x27787397 => 135
	i32 672442732, ; 42: System.Collections.Concurrent => 0x2814a96c => 94
	i32 690569205, ; 43: System.Xml.Linq.dll => 0x29293ff5 => 141
	i32 722857257, ; 44: System.Runtime.Loader.dll => 0x2b15ed29 => 128
	i32 748832960, ; 45: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 55
	i32 759454413, ; 46: System.Net.Requests => 0x2d445acd => 117
	i32 775507847, ; 47: System.IO.Compression => 0x2e394f87 => 110
	i32 777317022, ; 48: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 26
	i32 789151979, ; 49: Microsoft.Extensions.Options => 0x2f0980eb => 44
	i32 804715423, ; 50: System.Data.Common => 0x2ff6fb9f => 103
	i32 823281589, ; 51: System.Private.Uri.dll => 0x311247b5 => 120
	i32 830298997, ; 52: System.IO.Compression.Brotli => 0x317d5b75 => 109
	i32 869139383, ; 53: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 11
	i32 880668424, ; 54: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 25
	i32 904024072, ; 55: System.ComponentModel.Primitives.dll => 0x35e25008 => 99
	i32 918734561, ; 56: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 22
	i32 955402788, ; 57: Newtonsoft.Json => 0x38f24a24 => 52
	i32 961460050, ; 58: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 15
	i32 967690846, ; 59: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 71
	i32 975874589, ; 60: System.Xml.XDocument => 0x3a2aaa1d => 143
	i32 990727110, ; 61: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 24
	i32 992768348, ; 62: System.Collections.dll => 0x3b2c715c => 98
	i32 1012816738, ; 63: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 81
	i32 1019214401, ; 64: System.Drawing => 0x3cbffa41 => 107
	i32 1028951442, ; 65: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 41
	i32 1035644815, ; 66: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 60
	i32 1036536393, ; 67: System.Drawing.Primitives.dll => 0x3dc84a49 => 106
	i32 1043950537, ; 68: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 5
	i32 1044663988, ; 69: System.Linq.Expressions.dll => 0x3e444eb4 => 111
	i32 1052210849, ; 70: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 73
	i32 1082857460, ; 71: System.ComponentModel.TypeConverter => 0x408b17f4 => 100
	i32 1084122840, ; 72: Xamarin.Kotlin.StdLib => 0x409e66d8 => 90
	i32 1098259244, ; 73: System => 0x41761b2c => 144
	i32 1108272742, ; 74: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 27
	i32 1117529484, ; 75: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 21
	i32 1118262833, ; 76: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 17
	i32 1168523401, ; 77: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 23
	i32 1178241025, ; 78: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 78
	i32 1260983243, ; 79: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 3
	i32 1292207520, ; 80: SQLitePCLRaw.core.dll => 0x4d0585a0 => 56
	i32 1293217323, ; 81: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 69
	i32 1308624726, ; 82: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 12
	i32 1324164729, ; 83: System.Linq => 0x4eed2679 => 112
	i32 1336711579, ; 84: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 32
	i32 1373134921, ; 85: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 33
	i32 1376866003, ; 86: Xamarin.AndroidX.SavedState => 0x52114ed3 => 81
	i32 1391270679, ; 87: Namada Maui => 0x52ed1b17 => 92
	i32 1406073936, ; 88: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 65
	i32 1408764838, ; 89: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 130
	i32 1430672901, ; 90: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 1
	i32 1452070440, ; 91: System.Formats.Asn1.dll => 0x568cd628 => 108
	i32 1461004990, ; 92: es\Microsoft.Maui.Controls.resources => 0x57152abe => 7
	i32 1461234159, ; 93: System.Collections.Immutable.dll => 0x5718a9ef => 95
	i32 1462112819, ; 94: System.IO.Compression.dll => 0x57261233 => 110
	i32 1469204771, ; 95: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 61
	i32 1470490898, ; 96: Microsoft.Extensions.Primitives => 0x57a5e912 => 45
	i32 1479771757, ; 97: System.Collections.Immutable => 0x5833866d => 95
	i32 1480492111, ; 98: System.IO.Compression.Brotli.dll => 0x583e844f => 109
	i32 1524747670, ; 99: Plugin.LocalNotification => 0x5ae1cd96 => 53
	i32 1526286932, ; 100: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 31
	i32 1543031311, ; 101: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 137
	i32 1622152042, ; 102: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 75
	i32 1624863272, ; 103: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 84
	i32 1634654947, ; 104: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 37
	i32 1636350590, ; 105: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 67
	i32 1639515021, ; 106: System.Net.Http.dll => 0x61b9038d => 114
	i32 1639986890, ; 107: System.Text.RegularExpressions => 0x61c036ca => 137
	i32 1657153582, ; 108: System.Runtime => 0x62c6282e => 132
	i32 1658251792, ; 109: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 85
	i32 1677501392, ; 110: System.Net.Primitives.dll => 0x63fca3d0 => 116
	i32 1679769178, ; 111: System.Security.Cryptography => 0x641f3e5a => 133
	i32 1711441057, ; 112: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 57
	i32 1729485958, ; 113: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 63
	i32 1743415430, ; 114: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 2
	i32 1763938596, ; 115: System.Diagnostics.TraceSource.dll => 0x69239124 => 105
	i32 1766324549, ; 116: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 82
	i32 1770582343, ; 117: Microsoft.Extensions.Logging.dll => 0x6988f147 => 42
	i32 1780572499, ; 118: Mono.Android.Runtime.dll => 0x6a216153 => 148
	i32 1782862114, ; 119: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 18
	i32 1788241197, ; 120: Xamarin.AndroidX.Fragment => 0x6a96652d => 70
	i32 1793755602, ; 121: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 10
	i32 1808609942, ; 122: Xamarin.AndroidX.Loader => 0x6bcd3296 => 75
	i32 1813058853, ; 123: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 90
	i32 1813201214, ; 124: Xamarin.Google.Android.Material => 0x6c13413e => 85
	i32 1818569960, ; 125: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 79
	i32 1824175904, ; 126: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 127: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 130
	i32 1828688058, ; 128: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 43
	i32 1853025655, ; 129: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 27
	i32 1858542181, ; 130: System.Linq.Expressions => 0x6ec71a65 => 111
	i32 1870277092, ; 131: System.Reflection.Primitives => 0x6f7a29e4 => 125
	i32 1875935024, ; 132: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 9
	i32 1893218855, ; 133: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 3
	i32 1908813208, ; 134: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 87
	i32 1910275211, ; 135: System.Collections.NonGeneric.dll => 0x71dc7c8b => 96
	i32 1927140854, ; 136: Namada Maui.resources.dll => 0x72ddd5f6 => 0
	i32 1939592360, ; 137: System.Private.Xml.Linq => 0x739bd4a8 => 121
	i32 1953182387, ; 138: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 14
	i32 1968388702, ; 139: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 38
	i32 2003115576, ; 140: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 6
	i32 2019465201, ; 141: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 73
	i32 2045470958, ; 142: System.Private.Xml => 0x79eb68ee => 122
	i32 2055257422, ; 143: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 72
	i32 2066184531, ; 144: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 5
	i32 2070888862, ; 145: System.Diagnostics.TraceSource => 0x7b6f419e => 105
	i32 2079903147, ; 146: System.Runtime.dll => 0x7bf8cdab => 132
	i32 2090596640, ; 147: System.Numerics.Vectors => 0x7c9bf920 => 118
	i32 2103459038, ; 148: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 58
	i32 2127167465, ; 149: System.Console => 0x7ec9ffe9 => 102
	i32 2129483829, ; 150: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 86
	i32 2142473426, ; 151: System.Collections.Specialized => 0x7fb38cd2 => 97
	i32 2159891885, ; 152: Microsoft.Maui => 0x80bd55ad => 49
	i32 2169148018, ; 153: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 13
	i32 2181898931, ; 154: Microsoft.Extensions.Options.dll => 0x820d22b3 => 44
	i32 2192057212, ; 155: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 43
	i32 2193016926, ; 156: System.ObjectModel.dll => 0x82b6c85e => 119
	i32 2201107256, ; 157: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 91
	i32 2201231467, ; 158: System.Net.Http => 0x8334206b => 114
	i32 2207618523, ; 159: it\Microsoft.Maui.Controls.resources => 0x839595db => 15
	i32 2266799131, ; 160: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 39
	i32 2279755925, ; 161: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 80
	i32 2298471582, ; 162: System.Net.Mail => 0x88ffe49e => 115
	i32 2303942373, ; 163: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 19
	i32 2305521784, ; 164: System.Private.CoreLib.dll => 0x896b7878 => 146
	i32 2340441535, ; 165: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 126
	i32 2353062107, ; 166: System.Net.Primitives => 0x8c40e0db => 116
	i32 2366048013, ; 167: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 13
	i32 2368005991, ; 168: System.Xml.ReaderWriter.dll => 0x8d24e767 => 142
	i32 2371007202, ; 169: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 38
	i32 2395872292, ; 170: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 14
	i32 2401565422, ; 171: System.Web.HttpUtility => 0x8f24faee => 140
	i32 2427813419, ; 172: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 11
	i32 2435356389, ; 173: System.Console.dll => 0x912896e5 => 102
	i32 2465273461, ; 174: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 55
	i32 2471841756, ; 175: netstandard.dll => 0x93554fdc => 145
	i32 2475788418, ; 176: Java.Interop.dll => 0x93918882 => 147
	i32 2480646305, ; 177: Microsoft.Maui.Controls => 0x93dba8a1 => 47
	i32 2503351294, ; 178: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 17
	i32 2538310050, ; 179: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 124
	i32 2550873716, ; 180: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 12
	i32 2562349572, ; 181: Microsoft.CSharp => 0x98ba5a04 => 93
	i32 2570120770, ; 182: System.Text.Encodings.Web => 0x9930ee42 => 135
	i32 2576534780, ; 183: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 16
	i32 2585220780, ; 184: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2593496499, ; 185: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 21
	i32 2605712449, ; 186: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 91
	i32 2617129537, ; 187: System.Private.Xml.dll => 0x9bfe3a41 => 122
	i32 2620871830, ; 188: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 67
	i32 2626831493, ; 189: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 16
	i32 2663698177, ; 190: System.Runtime.Loader => 0x9ec4cf01 => 128
	i32 2664396074, ; 191: System.Xml.XDocument.dll => 0x9ecf752a => 143
	i32 2665622720, ; 192: System.Drawing.Primitives => 0x9ee22cc0 => 106
	i32 2676780864, ; 193: System.Data.Common.dll => 0x9f8c6f40 => 103
	i32 2724373263, ; 194: System.Runtime.Numerics.dll => 0xa262a30f => 129
	i32 2732626843, ; 195: Xamarin.AndroidX.Activity => 0xa2e0939b => 59
	i32 2737747696, ; 196: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 61
	i32 2740698338, ; 197: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 2
	i32 2752995522, ; 198: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 22
	i32 2758225723, ; 199: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 48
	i32 2764765095, ; 200: Microsoft.Maui.dll => 0xa4caf7a7 => 49
	i32 2778768386, ; 201: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 83
	i32 2785988530, ; 202: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 28
	i32 2801831435, ; 203: Microsoft.Maui.Graphics => 0xa7008e0b => 51
	i32 2810250172, ; 204: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 65
	i32 2847418871, ; 205: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 86
	i32 2853208004, ; 206: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 83
	i32 2861189240, ; 207: Microsoft.Maui.Essentials => 0xaa8a4878 => 50
	i32 2868488919, ; 208: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 37
	i32 2909740682, ; 209: System.Private.CoreLib => 0xad6f1e8a => 146
	i32 2916838712, ; 210: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 84
	i32 2919462931, ; 211: System.Numerics.Vectors.dll => 0xae037813 => 118
	i32 2959614098, ; 212: System.ComponentModel.dll => 0xb0682092 => 101
	i32 2978675010, ; 213: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 69
	i32 3038032645, ; 214: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 35
	i32 3053864966, ; 215: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 8
	i32 3057625584, ; 216: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 76
	i32 3058099980, ; 217: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 89
	i32 3059408633, ; 218: Mono.Android.Runtime => 0xb65adef9 => 148
	i32 3059793426, ; 219: System.ComponentModel.Primitives => 0xb660be12 => 99
	i32 3103600923, ; 220: System.Formats.Asn1 => 0xb8fd311b => 108
	i32 3159123045, ; 221: System.Reflection.Primitives.dll => 0xbc4c6465 => 125
	i32 3178803400, ; 222: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 77
	i32 3220365878, ; 223: System.Threading => 0xbff2e236 => 139
	i32 3230466174, ; 224: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 87
	i32 3258312781, ; 225: Xamarin.AndroidX.CardView => 0xc235e84d => 63
	i32 3286872994, ; 226: SQLite-net.dll => 0xc3e9b3a2 => 54
	i32 3305363605, ; 227: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 8
	i32 3316684772, ; 228: System.Net.Requests.dll => 0xc5b097e4 => 117
	i32 3317135071, ; 229: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 68
	i32 3346324047, ; 230: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 78
	i32 3357674450, ; 231: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 25
	i32 3358260929, ; 232: System.Text.Json => 0xc82afec1 => 136
	i32 3360279109, ; 233: SQLitePCLRaw.core => 0xc849ca45 => 56
	i32 3362522851, ; 234: Xamarin.AndroidX.Core => 0xc86c06e3 => 66
	i32 3366347497, ; 235: Java.Interop => 0xc8a662e9 => 147
	i32 3374999561, ; 236: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 80
	i32 3381016424, ; 237: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 4
	i32 3428513518, ; 238: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 40
	i32 3430777524, ; 239: netstandard => 0xcc7d82b4 => 145
	i32 3452344032, ; 240: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 46
	i32 3458724246, ; 241: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 23
	i32 3471940407, ; 242: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 100
	i32 3476120550, ; 243: Mono.Android => 0xcf3163e6 => 149
	i32 3484440000, ; 244: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 24
	i32 3485117614, ; 245: System.Text.Json.dll => 0xcfbaacae => 136
	i32 3494395880, ; 246: Xamarin.GooglePlayServices.Location.dll => 0xd0483fe8 => 88
	i32 3509114376, ; 247: System.Xml.Linq => 0xd128d608 => 141
	i32 3580758918, ; 248: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 32
	i32 3592228221, ; 249: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 34
	i32 3608519521, ; 250: System.Linq.dll => 0xd715a361 => 112
	i32 3624195450, ; 251: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 126
	i32 3641597786, ; 252: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 72
	i32 3643446276, ; 253: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 29
	i32 3643854240, ; 254: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 77
	i32 3657292374, ; 255: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 39
	i32 3672681054, ; 256: Mono.Android.dll => 0xdae8aa5e => 149
	i32 3682565725, ; 257: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 62
	i32 3724971120, ; 258: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 76
	i32 3748608112, ; 259: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 104
	i32 3751619990, ; 260: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 4
	i32 3754567612, ; 261: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 58
	i32 3786282454, ; 262: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 64
	i32 3792276235, ; 263: System.Collections.NonGeneric => 0xe2098b0b => 96
	i32 3800979733, ; 264: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 46
	i32 3802395368, ; 265: System.Collections.Specialized.dll => 0xe2a3f2e8 => 97
	i32 3817368567, ; 266: CommunityToolkit.Maui.dll => 0xe3886bf7 => 36
	i32 3823082795, ; 267: System.Security.Cryptography.dll => 0xe3df9d2b => 133
	i32 3841636137, ; 268: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 41
	i32 3844307129, ; 269: System.Net.Mail.dll => 0xe52378b9 => 115
	i32 3849253459, ; 270: System.Runtime.InteropServices.dll => 0xe56ef253 => 127
	i32 3876362041, ; 271: SQLite-net => 0xe70c9739 => 54
	i32 3896106733, ; 272: System.Collections.Concurrent.dll => 0xe839deed => 94
	i32 3896760992, ; 273: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 66
	i32 3920221145, ; 274: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 20
	i32 3928044579, ; 275: System.Xml.ReaderWriter => 0xea213423 => 142
	i32 3931092270, ; 276: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 79
	i32 3955647286, ; 277: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 60
	i32 3967165417, ; 278: Xamarin.GooglePlayServices.Location => 0xec7623e9 => 88
	i32 3970018735, ; 279: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 89
	i32 4025784931, ; 280: System.Memory => 0xeff49a63 => 113
	i32 4046471985, ; 281: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 48
	i32 4054681211, ; 282: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 123
	i32 4068434129, ; 283: System.Private.Xml.Linq.dll => 0xf27f60d1 => 121
	i32 4073602200, ; 284: System.Threading.dll => 0xf2ce3c98 => 139
	i32 4091086043, ; 285: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 6
	i32 4094352644, ; 286: Microsoft.Maui.Essentials.dll => 0xf40add04 => 50
	i32 4099507663, ; 287: System.Drawing.dll => 0xf45985cf => 107
	i32 4100113165, ; 288: System.Private.Uri => 0xf462c30d => 120
	i32 4103439459, ; 289: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 30
	i32 4126470640, ; 290: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 40
	i32 4147896353, ; 291: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 123
	i32 4150914736, ; 292: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 30
	i32 4181436372, ; 293: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 131
	i32 4182413190, ; 294: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 74
	i32 4213026141, ; 295: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 104
	i32 4249188766, ; 296: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 19
	i32 4271975918, ; 297: Microsoft.Maui.Controls.dll => 0xfea12dee => 47
	i32 4274976490, ; 298: System.Runtime.Numerics => 0xfecef6ea => 129
	i32 4292120959 ; 299: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 74
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [300 x i32] [
	i32 1, ; 0
	i32 52, ; 1
	i32 10, ; 2
	i32 138, ; 3
	i32 34, ; 4
	i32 51, ; 5
	i32 18, ; 6
	i32 127, ; 7
	i32 92, ; 8
	i32 33, ; 9
	i32 26, ; 10
	i32 64, ; 11
	i32 82, ; 12
	i32 101, ; 13
	i32 62, ; 14
	i32 93, ; 15
	i32 124, ; 16
	i32 31, ; 17
	i32 59, ; 18
	i32 9, ; 19
	i32 71, ; 20
	i32 57, ; 21
	i32 138, ; 22
	i32 113, ; 23
	i32 35, ; 24
	i32 29, ; 25
	i32 0, ; 26
	i32 98, ; 27
	i32 70, ; 28
	i32 140, ; 29
	i32 131, ; 30
	i32 144, ; 31
	i32 7, ; 32
	i32 119, ; 33
	i32 53, ; 34
	i32 45, ; 35
	i32 28, ; 36
	i32 42, ; 37
	i32 36, ; 38
	i32 68, ; 39
	i32 20, ; 40
	i32 135, ; 41
	i32 94, ; 42
	i32 141, ; 43
	i32 128, ; 44
	i32 55, ; 45
	i32 117, ; 46
	i32 110, ; 47
	i32 26, ; 48
	i32 44, ; 49
	i32 103, ; 50
	i32 120, ; 51
	i32 109, ; 52
	i32 11, ; 53
	i32 25, ; 54
	i32 99, ; 55
	i32 22, ; 56
	i32 52, ; 57
	i32 15, ; 58
	i32 71, ; 59
	i32 143, ; 60
	i32 24, ; 61
	i32 98, ; 62
	i32 81, ; 63
	i32 107, ; 64
	i32 41, ; 65
	i32 60, ; 66
	i32 106, ; 67
	i32 5, ; 68
	i32 111, ; 69
	i32 73, ; 70
	i32 100, ; 71
	i32 90, ; 72
	i32 144, ; 73
	i32 27, ; 74
	i32 21, ; 75
	i32 17, ; 76
	i32 23, ; 77
	i32 78, ; 78
	i32 3, ; 79
	i32 56, ; 80
	i32 69, ; 81
	i32 12, ; 82
	i32 112, ; 83
	i32 32, ; 84
	i32 33, ; 85
	i32 81, ; 86
	i32 92, ; 87
	i32 65, ; 88
	i32 130, ; 89
	i32 1, ; 90
	i32 108, ; 91
	i32 7, ; 92
	i32 95, ; 93
	i32 110, ; 94
	i32 61, ; 95
	i32 45, ; 96
	i32 95, ; 97
	i32 109, ; 98
	i32 53, ; 99
	i32 31, ; 100
	i32 137, ; 101
	i32 75, ; 102
	i32 84, ; 103
	i32 37, ; 104
	i32 67, ; 105
	i32 114, ; 106
	i32 137, ; 107
	i32 132, ; 108
	i32 85, ; 109
	i32 116, ; 110
	i32 133, ; 111
	i32 57, ; 112
	i32 63, ; 113
	i32 2, ; 114
	i32 105, ; 115
	i32 82, ; 116
	i32 42, ; 117
	i32 148, ; 118
	i32 18, ; 119
	i32 70, ; 120
	i32 10, ; 121
	i32 75, ; 122
	i32 90, ; 123
	i32 85, ; 124
	i32 79, ; 125
	i32 134, ; 126
	i32 130, ; 127
	i32 43, ; 128
	i32 27, ; 129
	i32 111, ; 130
	i32 125, ; 131
	i32 9, ; 132
	i32 3, ; 133
	i32 87, ; 134
	i32 96, ; 135
	i32 0, ; 136
	i32 121, ; 137
	i32 14, ; 138
	i32 38, ; 139
	i32 6, ; 140
	i32 73, ; 141
	i32 122, ; 142
	i32 72, ; 143
	i32 5, ; 144
	i32 105, ; 145
	i32 132, ; 146
	i32 118, ; 147
	i32 58, ; 148
	i32 102, ; 149
	i32 86, ; 150
	i32 97, ; 151
	i32 49, ; 152
	i32 13, ; 153
	i32 44, ; 154
	i32 43, ; 155
	i32 119, ; 156
	i32 91, ; 157
	i32 114, ; 158
	i32 15, ; 159
	i32 39, ; 160
	i32 80, ; 161
	i32 115, ; 162
	i32 19, ; 163
	i32 146, ; 164
	i32 126, ; 165
	i32 116, ; 166
	i32 13, ; 167
	i32 142, ; 168
	i32 38, ; 169
	i32 14, ; 170
	i32 140, ; 171
	i32 11, ; 172
	i32 102, ; 173
	i32 55, ; 174
	i32 145, ; 175
	i32 147, ; 176
	i32 47, ; 177
	i32 17, ; 178
	i32 124, ; 179
	i32 12, ; 180
	i32 93, ; 181
	i32 135, ; 182
	i32 16, ; 183
	i32 134, ; 184
	i32 21, ; 185
	i32 91, ; 186
	i32 122, ; 187
	i32 67, ; 188
	i32 16, ; 189
	i32 128, ; 190
	i32 143, ; 191
	i32 106, ; 192
	i32 103, ; 193
	i32 129, ; 194
	i32 59, ; 195
	i32 61, ; 196
	i32 2, ; 197
	i32 22, ; 198
	i32 48, ; 199
	i32 49, ; 200
	i32 83, ; 201
	i32 28, ; 202
	i32 51, ; 203
	i32 65, ; 204
	i32 86, ; 205
	i32 83, ; 206
	i32 50, ; 207
	i32 37, ; 208
	i32 146, ; 209
	i32 84, ; 210
	i32 118, ; 211
	i32 101, ; 212
	i32 69, ; 213
	i32 35, ; 214
	i32 8, ; 215
	i32 76, ; 216
	i32 89, ; 217
	i32 148, ; 218
	i32 99, ; 219
	i32 108, ; 220
	i32 125, ; 221
	i32 77, ; 222
	i32 139, ; 223
	i32 87, ; 224
	i32 63, ; 225
	i32 54, ; 226
	i32 8, ; 227
	i32 117, ; 228
	i32 68, ; 229
	i32 78, ; 230
	i32 25, ; 231
	i32 136, ; 232
	i32 56, ; 233
	i32 66, ; 234
	i32 147, ; 235
	i32 80, ; 236
	i32 4, ; 237
	i32 40, ; 238
	i32 145, ; 239
	i32 46, ; 240
	i32 23, ; 241
	i32 100, ; 242
	i32 149, ; 243
	i32 24, ; 244
	i32 136, ; 245
	i32 88, ; 246
	i32 141, ; 247
	i32 32, ; 248
	i32 34, ; 249
	i32 112, ; 250
	i32 126, ; 251
	i32 72, ; 252
	i32 29, ; 253
	i32 77, ; 254
	i32 39, ; 255
	i32 149, ; 256
	i32 62, ; 257
	i32 76, ; 258
	i32 104, ; 259
	i32 4, ; 260
	i32 58, ; 261
	i32 64, ; 262
	i32 96, ; 263
	i32 46, ; 264
	i32 97, ; 265
	i32 36, ; 266
	i32 133, ; 267
	i32 41, ; 268
	i32 115, ; 269
	i32 127, ; 270
	i32 54, ; 271
	i32 94, ; 272
	i32 66, ; 273
	i32 20, ; 274
	i32 142, ; 275
	i32 79, ; 276
	i32 60, ; 277
	i32 88, ; 278
	i32 89, ; 279
	i32 113, ; 280
	i32 48, ; 281
	i32 123, ; 282
	i32 121, ; 283
	i32 139, ; 284
	i32 6, ; 285
	i32 50, ; 286
	i32 107, ; 287
	i32 120, ; 288
	i32 30, ; 289
	i32 40, ; 290
	i32 123, ; 291
	i32 30, ; 292
	i32 131, ; 293
	i32 74, ; 294
	i32 104, ; 295
	i32 19, ; 296
	i32 47, ; 297
	i32 129, ; 298
	i32 74 ; 299
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
