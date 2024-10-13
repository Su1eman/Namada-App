; ModuleID = 'marshal_methods.arm64-v8a.ll'
source_filename = "marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [150 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [300 x i64] [
	i64 36418902923615093, ; 0: Plugin.LocalNotification => 0x8162cc9bdf1b75 => 53
	i64 98382396393917666, ; 1: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 45
	i64 120698629574877762, ; 2: Mono.Android => 0x1accec39cafe242 => 149
	i64 131669012237370309, ; 3: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 50
	i64 196720943101637631, ; 4: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 111
	i64 210515253464952879, ; 5: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 64
	i64 232391251801502327, ; 6: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 81
	i64 435170709725415398, ; 7: Xamarin.GooglePlayServices.Location => 0x60a097471d687e6 => 88
	i64 560278790331054453, ; 8: System.Reflection.Primitives => 0x7c6829760de3975 => 125
	i64 687654259221141486, ; 9: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 86
	i64 750875890346172408, ; 10: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 138
	i64 799765834175365804, ; 11: System.ComponentModel.dll => 0xb1956c9f18442ac => 101
	i64 805302231655005164, ; 12: hu\Microsoft.Maui.Controls.resources.dll => 0xb2d021ceea03bec => 13
	i64 870603111519317375, ; 13: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 57
	i64 872800313462103108, ; 14: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 69
	i64 1010599046655515943, ; 15: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 125
	i64 1120440138749646132, ; 16: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 85
	i64 1268860745194512059, ; 17: System.Drawing.dll => 0x119be62002c19ebb => 107
	i64 1301485588176585670, ; 18: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 56
	i64 1369545283391376210, ; 19: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 77
	i64 1476839205573959279, ; 20: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 116
	i64 1486715745332614827, ; 21: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 47
	i64 1513467482682125403, ; 22: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 148
	i64 1518315023656898250, ; 23: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 58
	i64 1537168428375924959, ; 24: System.Threading.Thread.dll => 0x15551e8a954ae0df => 138
	i64 1624659445732251991, ; 25: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 61
	i64 1628611045998245443, ; 26: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 74
	i64 1731380447121279447, ; 27: Newtonsoft.Json => 0x18071957e9b889d7 => 52
	i64 1735388228521408345, ; 28: System.Net.Mail.dll => 0x181556663c69b759 => 115
	i64 1743969030606105336, ; 29: System.Memory.dll => 0x1833d297e88f2af8 => 113
	i64 1767386781656293639, ; 30: System.Private.Uri.dll => 0x188704e9f5582107 => 120
	i64 1795316252682057001, ; 31: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 60
	i64 1825687700144851180, ; 32: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 126
	i64 1835311033149317475, ; 33: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 7
	i64 1836611346387731153, ; 34: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 81
	i64 1875417405349196092, ; 35: System.Drawing.Primitives => 0x1a06d2319b6c713c => 106
	i64 1881198190668717030, ; 36: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 29
	i64 1920760634179481754, ; 37: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 48
	i64 1981742497975770890, ; 38: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 73
	i64 2102659300918482391, ; 39: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 106
	i64 2133195048986300728, ; 40: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 52
	i64 2165725771938924357, ; 41: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 62
	i64 2262844636196693701, ; 42: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 69
	i64 2287834202362508563, ; 43: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 94
	i64 2329709569556905518, ; 44: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 72
	i64 2335503487726329082, ; 45: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 135
	i64 2470498323731680442, ; 46: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 65
	i64 2497223385847772520, ; 47: System.Runtime => 0x22a7eb7046413568 => 132
	i64 2547086958574651984, ; 48: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 59
	i64 2602673633151553063, ; 49: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 28
	i64 2656907746661064104, ; 50: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 40
	i64 2662981627730767622, ; 51: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 3
	i64 2895129759130297543, ; 52: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 8
	i64 3017704767998173186, ; 53: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 85
	i64 3289520064315143713, ; 54: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 71
	i64 3311221304742556517, ; 55: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 118
	i64 3325875462027654285, ; 56: System.Runtime.Numerics => 0x2e27e21c8958b48d => 129
	i64 3344514922410554693, ; 57: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 91
	i64 3411255996856937470, ; 58: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 87
	i64 3429672777697402584, ; 59: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 50
	i64 3494946837667399002, ; 60: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 38
	i64 3522470458906976663, ; 61: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 82
	i64 3523440809810570850, ; 62: Namada Maui => 0x30e5c6bf9fdfae62 => 92
	i64 3551103847008531295, ; 63: System.Private.CoreLib.dll => 0x31480e226177735f => 146
	i64 3567343442040498961, ; 64: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 23
	i64 3571415421602489686, ; 65: System.Runtime.dll => 0x319037675df7e556 => 132
	i64 3638003163729360188, ; 66: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 39
	i64 3647754201059316852, ; 67: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 142
	i64 3655542548057982301, ; 68: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 38
	i64 3716579019761409177, ; 69: netstandard.dll => 0x3393f0ed5c8c5c99 => 145
	i64 3727469159507183293, ; 70: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 80
	i64 3869221888984012293, ; 71: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 42
	i64 3890352374528606784, ; 72: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 48
	i64 3933965368022646939, ; 73: System.Net.Requests => 0x369840a8bfadc09b => 117
	i64 3966267475168208030, ; 74: System.Memory => 0x370b03412596249e => 113
	i64 4009997192427317104, ; 75: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 131
	i64 4070326265757318011, ; 76: da\Microsoft.Maui.Controls.resources.dll => 0x387cb42c56683b7b => 4
	i64 4073500526318903918, ; 77: System.Private.Xml.dll => 0x3887fb25779ae26e => 122
	i64 4073631083018132676, ; 78: Microsoft.Maui.Controls.Compatibility.dll => 0x388871e311491cc4 => 46
	i64 4120493066591692148, ; 79: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 34
	i64 4154383907710350974, ; 80: System.ComponentModel => 0x39a7562737acb67e => 101
	i64 4187479170553454871, ; 81: System.Linq.Expressions => 0x3a1cea1e912fa117 => 111
	i64 4205801962323029395, ; 82: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 100
	i64 4247996603072512073, ; 83: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 89
	i64 4337444564132831293, ; 84: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 55
	i64 4360412976914417659, ; 85: tr\Microsoft.Maui.Controls.resources.dll => 0x3c834c8002fcc7fb => 29
	i64 4477672992252076438, ; 86: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 140
	i64 4794310189461587505, ; 87: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 59
	i64 4795410492532947900, ; 88: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 82
	i64 4809057822547766521, ; 89: System.Drawing => 0x42bd349c3145ecf9 => 107
	i64 4853321196694829351, ; 90: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 128
	i64 4871824391508510238, ; 91: nb\Microsoft.Maui.Controls.resources.dll => 0x439c3278d7f2c61e => 19
	i64 4953714692329509532, ; 92: sv\Microsoft.Maui.Controls.resources.dll => 0x44bf21444aef129c => 27
	i64 5103417709280584325, ; 93: System.Collections.Specialized => 0x46d2fb5e161b6285 => 97
	i64 5182934613077526976, ; 94: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 97
	i64 5290786973231294105, ; 95: System.Runtime.Loader => 0x496ca6b869b72699 => 128
	i64 5423376490970181369, ; 96: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 126
	i64 5471532531798518949, ; 97: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 27
	i64 5522859530602327440, ; 98: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 30
	i64 5528247634813456972, ; 99: Plugin.LocalNotification.dll => 0x4cb847ef1773124c => 53
	i64 5570799893513421663, ; 100: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 109
	i64 5573260873512690141, ; 101: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 133
	i64 5586159943986222360, ; 102: Namada Maui.resources => 0x4d8606df4fd09518 => 0
	i64 5692067934154308417, ; 103: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 84
	i64 5979151488806146654, ; 104: System.Formats.Asn1 => 0x52fa3699a489d25e => 108
	i64 6183170893902868313, ; 105: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 55
	i64 6200764641006662125, ; 106: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 24
	i64 6222399776351216807, ; 107: System.Text.Json.dll => 0x565a67a0ffe264a7 => 136
	i64 6284145129771520194, ; 108: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 123
	i64 6300676701234028427, ; 109: es\Microsoft.Maui.Controls.resources.dll => 0x57708013cda25f8b => 7
	i64 6357457916754632952, ; 110: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 35
	i64 6401687960814735282, ; 111: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 72
	i64 6471714727257221498, ; 112: fi\Microsoft.Maui.Controls.resources.dll => 0x59d026417dd4a97a => 8
	i64 6478287442656530074, ; 113: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 12
	i64 6504860066809920875, ; 114: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 62
	i64 6548213210057960872, ; 115: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 68
	i64 6560151584539558821, ; 116: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 44
	i64 6743165466166707109, ; 117: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 20
	i64 6786606130239981554, ; 118: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 105
	i64 6814185388980153342, ; 119: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 143
	i64 6876862101832370452, ; 120: System.Xml.Linq => 0x5f6f85a57d108914 => 141
	i64 6894844156784520562, ; 121: System.Numerics.Vectors => 0x5faf683aead1ad72 => 118
	i64 7083547580668757502, ; 122: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 121
	i64 7270811800166795866, ; 123: System.Linq => 0x64e71ccf51a90a5a => 112
	i64 7275339109999372139, ; 124: Namada Maui.dll => 0x64f7325fc804e76b => 92
	i64 7377312882064240630, ; 125: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 100
	i64 7488575175965059935, ; 126: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 141
	i64 7489048572193775167, ; 127: System.ObjectModel => 0x67ee71ff6b419e3f => 119
	i64 7654504624184590948, ; 128: System.Net.Http => 0x6a3a4366801b8264 => 114
	i64 7694700312542370399, ; 129: System.Net.Mail => 0x6ac9112a7e2cda5f => 115
	i64 7714652370974252055, ; 130: System.Private.CoreLib => 0x6b0ff375198b9c17 => 146
	i64 7735176074855944702, ; 131: Microsoft.CSharp => 0x6b58dda848e391fe => 93
	i64 7735352534559001595, ; 132: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 90
	i64 7742555799473854801, ; 133: it\Microsoft.Maui.Controls.resources.dll => 0x6b73157a51479951 => 15
	i64 7836164640616011524, ; 134: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 61
	i64 7975724199463739455, ; 135: sk\Microsoft.Maui.Controls.resources.dll => 0x6eaf76e6f785e03f => 26
	i64 8064050204834738623, ; 136: System.Collections.dll => 0x6fe942efa61731bf => 98
	i64 8083354569033831015, ; 137: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 71
	i64 8087206902342787202, ; 138: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 104
	i64 8108129031893776750, ; 139: ko\Microsoft.Maui.Controls.resources.dll => 0x7085dc65530f796e => 17
	i64 8167236081217502503, ; 140: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 147
	i64 8185542183669246576, ; 141: System.Collections => 0x7198e33f4794aa70 => 98
	i64 8246048515196606205, ; 142: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 51
	i64 8368701292315763008, ; 143: System.Security.Cryptography => 0x7423997c6fd56140 => 133
	i64 8386351099740279196, ; 144: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x74624de475b9d19c => 32
	i64 8400357532724379117, ; 145: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 79
	i64 8410671156615598628, ; 146: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 124
	i64 8518412311883997971, ; 147: System.Collections.Immutable => 0x76377add7c28e313 => 95
	i64 8563666267364444763, ; 148: System.Private.Uri => 0x76d841191140ca5b => 120
	i64 8599632406834268464, ; 149: CommunityToolkit.Maui => 0x7758081c784b4930 => 36
	i64 8626175481042262068, ; 150: Java.Interop => 0x77b654e585b55834 => 147
	i64 8638972117149407195, ; 151: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 93
	i64 8639588376636138208, ; 152: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 78
	i64 8677882282824630478, ; 153: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 22
	i64 8725526185868997716, ; 154: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 104
	i64 8941376889969657626, ; 155: System.Xml.XDocument => 0x7c1626e87187471a => 143
	i64 9045785047181495996, ; 156: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 32
	i64 9312692141327339315, ; 157: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 84
	i64 9324707631942237306, ; 158: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 60
	i64 9363564275759486853, ; 159: el\Microsoft.Maui.Controls.resources.dll => 0x81f21019382e9785 => 6
	i64 9551379474083066910, ; 160: uk\Microsoft.Maui.Controls.resources.dll => 0x848d5106bbadb41e => 30
	i64 9659729154652888475, ; 161: System.Text.RegularExpressions => 0x860e407c9991dd9b => 137
	i64 9678050649315576968, ; 162: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 65
	i64 9702891218465930390, ; 163: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 96
	i64 9773637193738963987, ; 164: ca\Microsoft.Maui.Controls.resources.dll => 0x87a2ef3ea85b4c13 => 2
	i64 9808709177481450983, ; 165: Mono.Android.dll => 0x881f890734e555e7 => 149
	i64 9875200773399460291, ; 166: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 86
	i64 9956195530459977388, ; 167: Microsoft.Maui => 0x8a2b8315b36616ac => 49
	i64 10038780035334861115, ; 168: System.Net.Http.dll => 0x8b50e941206af13b => 114
	i64 10051358222726253779, ; 169: System.Private.Xml => 0x8b7d990c97ccccd3 => 122
	i64 10092835686693276772, ; 170: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 47
	i64 10143853363526200146, ; 171: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 4
	i64 10209869394718195525, ; 172: nl\Microsoft.Maui.Controls.resources.dll => 0x8db0be1ecb4f7f45 => 20
	i64 10229024438826829339, ; 173: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 68
	i64 10245369515835430794, ; 174: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 124
	i64 10364469296367737616, ; 175: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 123
	i64 10406448008575299332, ; 176: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 91
	i64 10430153318873392755, ; 177: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 66
	i64 10506226065143327199, ; 178: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 2
	i64 10761706286639228993, ; 179: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0x955942d988382841 => 34
	i64 10785150219063592792, ; 180: System.Net.Primitives => 0x95ac8cfb68830758 => 116
	i64 10880838204485145808, ; 181: CommunityToolkit.Maui.dll => 0x970080b2a4d614d0 => 36
	i64 11002576679268595294, ; 182: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 43
	i64 11009005086950030778, ; 183: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 49
	i64 11103970607964515343, ; 184: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 13
	i64 11156122287428000958, ; 185: th\Microsoft.Maui.Controls.resources.dll => 0x9ad2821cdcf6dcbe => 28
	i64 11157797727133427779, ; 186: fr\Microsoft.Maui.Controls.resources.dll => 0x9ad875ea9172e843 => 9
	i64 11162124722117608902, ; 187: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 83
	i64 11220793807500858938, ; 188: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 16
	i64 11226290749488709958, ; 189: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 44
	i64 11340910727871153756, ; 190: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 67
	i64 11485890710487134646, ; 191: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 127
	i64 11518296021396496455, ; 192: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 14
	i64 11529969570048099689, ; 193: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 83
	i64 11530571088791430846, ; 194: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 42
	i64 11597940890313164233, ; 195: netstandard => 0xa0f429ca8d1805c9 => 145
	i64 11739066727115742305, ; 196: SQLite-net.dll => 0xa2e98afdf8575c61 => 54
	i64 11806260347154423189, ; 197: SQLite-net => 0xa3d8433bc5eb5d95 => 54
	i64 11855031688536399763, ; 198: vi\Microsoft.Maui.Controls.resources.dll => 0xa485888294361f93 => 31
	i64 12145679461940342714, ; 199: System.Text.Json => 0xa88e1f1ebcb62fba => 136
	i64 12201331334810686224, ; 200: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 131
	i64 12269460666702402136, ; 201: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 95
	i64 12279246230491828964, ; 202: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 58
	i64 12341818387765915815, ; 203: CommunityToolkit.Maui.Core.dll => 0xab46f26f152bf0a7 => 37
	i64 12451044538927396471, ; 204: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 70
	i64 12466513435562512481, ; 205: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 75
	i64 12475113361194491050, ; 206: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 35
	i64 12517810545449516888, ; 207: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 105
	i64 12538491095302438457, ; 208: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 63
	i64 12550732019250633519, ; 209: System.IO.Compression => 0xae2d28465e8e1b2f => 110
	i64 12700543734426720211, ; 210: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 64
	i64 12708922737231849740, ; 211: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 134
	i64 12843321153144804894, ; 212: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 45
	i64 12989346753972519995, ; 213: ar\Microsoft.Maui.Controls.resources.dll => 0xb4436e0d5ee7c43b => 1
	i64 13005833372463390146, ; 214: pt-BR\Microsoft.Maui.Controls.resources.dll => 0xb47e008b5d99ddc2 => 22
	i64 13068258254871114833, ; 215: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 130
	i64 13343850469010654401, ; 216: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 148
	i64 13381594904270902445, ; 217: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 10
	i64 13465488254036897740, ; 218: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 90
	i64 13540124433173649601, ; 219: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 31
	i64 13572454107664307259, ; 220: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 80
	i64 13717397318615465333, ; 221: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 99
	i64 13881769479078963060, ; 222: System.Console.dll => 0xc0a5f3cade5c6774 => 102
	i64 13959074834287824816, ; 223: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 70
	i64 14124974489674258913, ; 224: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 63
	i64 14125464355221830302, ; 225: System.Threading.dll => 0xc407bafdbc707a9e => 139
	i64 14254574811015963973, ; 226: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 134
	i64 14349907877893689639, ; 227: ro\Microsoft.Maui.Controls.resources.dll => 0xc7251d2f956ed127 => 24
	i64 14461014870687870182, ; 228: System.Net.Requests.dll => 0xc8afd8683afdece6 => 117
	i64 14464374589798375073, ; 229: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 25
	i64 14491877563792607819, ; 230: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0xc91d7ddcee4fca4b => 33
	i64 14551742072151931844, ; 231: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 135
	i64 14556034074661724008, ; 232: CommunityToolkit.Maui.Core => 0xca016bdea6b19f68 => 37
	i64 14610046442689856844, ; 233: cs\Microsoft.Maui.Controls.resources.dll => 0xcac14fd5107d054c => 3
	i64 14622043554576106986, ; 234: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 130
	i64 14669215534098758659, ; 235: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 40
	i64 14678510994762383812, ; 236: Xamarin.GooglePlayServices.Location.dll => 0xcbb48bfaca7a41c4 => 88
	i64 14690985099581930927, ; 237: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 140
	i64 14705122255218365489, ; 238: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 17
	i64 14735017007120366644, ; 239: ja\Microsoft.Maui.Controls.resources.dll => 0xcc7d4be604bfbc34 => 16
	i64 14744092281598614090, ; 240: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 33
	i64 14852515768018889994, ; 241: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 67
	i64 14904040806490515477, ; 242: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 1
	i64 14954917835170835695, ; 243: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 41
	i64 14987728460634540364, ; 244: System.IO.Compression.dll => 0xcfff1ba06622494c => 110
	i64 15076659072870671916, ; 245: System.ObjectModel.dll => 0xd13b0d8c1620662c => 119
	i64 15111608613780139878, ; 246: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 18
	i64 15115185479366240210, ; 247: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 109
	i64 15133485256822086103, ; 248: System.Linq.dll => 0xd204f0a9127dd9d7 => 112
	i64 15203009853192377507, ; 249: pt\Microsoft.Maui.Controls.resources.dll => 0xd2fbf0e9984b94a3 => 23
	i64 15227001540531775957, ; 250: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 39
	i64 15370334346939861994, ; 251: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 66
	i64 15391712275433856905, ; 252: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 41
	i64 15527772828719725935, ; 253: System.Console => 0xd77dbb1e38cd3d6f => 102
	i64 15536481058354060254, ; 254: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 5
	i64 15582737692548360875, ; 255: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 74
	i64 15609085926864131306, ; 256: System.dll => 0xd89e9cf3334914ea => 144
	i64 15661133872274321916, ; 257: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 142
	i64 15783653065526199428, ; 258: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 6
	i64 15928521404965645318, ; 259: Microsoft.Maui.Controls.Compatibility => 0xdd0d79d32c2eec06 => 46
	i64 15930129725311349754, ; 260: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 89
	i64 16056281320585338352, ; 261: ru\Microsoft.Maui.Controls.resources.dll => 0xded35eca8f3a9df0 => 25
	i64 16154507427712707110, ; 262: System => 0xe03056ea4e39aa26 => 144
	i64 16288847719894691167, ; 263: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 19
	i64 16321164108206115771, ; 264: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 43
	i64 16649148416072044166, ; 265: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 51
	i64 16677317093839702854, ; 266: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 79
	i64 16755018182064898362, ; 267: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 56
	i64 16803648858859583026, ; 268: ms\Microsoft.Maui.Controls.resources.dll => 0xe9328d9b8ab93632 => 18
	i64 16856067890322379635, ; 269: System.Data.Common.dll => 0xe9ecc87060889373 => 103
	i64 16890310621557459193, ; 270: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 137
	i64 16942731696432749159, ; 271: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 26
	i64 16982071006676315159, ; 272: Namada Maui.resources.dll => 0xebac6f9b0f66ec17 => 0
	i64 16998075588627545693, ; 273: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 77
	i64 17008137082415910100, ; 274: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 96
	i64 17031351772568316411, ; 275: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 76
	i64 17062143951396181894, ; 276: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 99
	i64 17203614576212522419, ; 277: pl\Microsoft.Maui.Controls.resources.dll => 0xeebf844ef3e135b3 => 21
	i64 17230721278011714856, ; 278: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 121
	i64 17260702271250283638, ; 279: System.Data.Common => 0xef8a5543bba6bc76 => 103
	i64 17310278548634113468, ; 280: hi\Microsoft.Maui.Controls.resources.dll => 0xf03a76a04e6695bc => 11
	i64 17342750010158924305, ; 281: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 11
	i64 17514990004910432069, ; 282: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 9
	i64 17623389608345532001, ; 283: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 21
	i64 17704177640604968747, ; 284: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 75
	i64 17710060891934109755, ; 285: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 73
	i64 17712670374920797664, ; 286: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 127
	i64 17777860260071588075, ; 287: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 129
	i64 17827813215687577648, ; 288: hr\Microsoft.Maui.Controls.resources.dll => 0xf7691da9f3129030 => 12
	i64 17942426894774770628, ; 289: de\Microsoft.Maui.Controls.resources.dll => 0xf9004e329f771bc4 => 5
	i64 17986907704309214542, ; 290: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 87
	i64 18025913125965088385, ; 291: System.Threading => 0xfa28e87b91334681 => 139
	i64 18121036031235206392, ; 292: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 76
	i64 18146411883821974900, ; 293: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 108
	i64 18245806341561545090, ; 294: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 94
	i64 18305135509493619199, ; 295: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 78
	i64 18324163916253801303, ; 296: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 15
	i64 18342408478508122430, ; 297: id\Microsoft.Maui.Controls.resources.dll => 0xfe8d53543697013e => 14
	i64 18358161419737137786, ; 298: he\Microsoft.Maui.Controls.resources.dll => 0xfec54a8ba8b6827a => 10
	i64 18370042311372477656 ; 299: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 57
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [300 x i32] [
	i32 53, ; 0
	i32 45, ; 1
	i32 149, ; 2
	i32 50, ; 3
	i32 111, ; 4
	i32 64, ; 5
	i32 81, ; 6
	i32 88, ; 7
	i32 125, ; 8
	i32 86, ; 9
	i32 138, ; 10
	i32 101, ; 11
	i32 13, ; 12
	i32 57, ; 13
	i32 69, ; 14
	i32 125, ; 15
	i32 85, ; 16
	i32 107, ; 17
	i32 56, ; 18
	i32 77, ; 19
	i32 116, ; 20
	i32 47, ; 21
	i32 148, ; 22
	i32 58, ; 23
	i32 138, ; 24
	i32 61, ; 25
	i32 74, ; 26
	i32 52, ; 27
	i32 115, ; 28
	i32 113, ; 29
	i32 120, ; 30
	i32 60, ; 31
	i32 126, ; 32
	i32 7, ; 33
	i32 81, ; 34
	i32 106, ; 35
	i32 29, ; 36
	i32 48, ; 37
	i32 73, ; 38
	i32 106, ; 39
	i32 52, ; 40
	i32 62, ; 41
	i32 69, ; 42
	i32 94, ; 43
	i32 72, ; 44
	i32 135, ; 45
	i32 65, ; 46
	i32 132, ; 47
	i32 59, ; 48
	i32 28, ; 49
	i32 40, ; 50
	i32 3, ; 51
	i32 8, ; 52
	i32 85, ; 53
	i32 71, ; 54
	i32 118, ; 55
	i32 129, ; 56
	i32 91, ; 57
	i32 87, ; 58
	i32 50, ; 59
	i32 38, ; 60
	i32 82, ; 61
	i32 92, ; 62
	i32 146, ; 63
	i32 23, ; 64
	i32 132, ; 65
	i32 39, ; 66
	i32 142, ; 67
	i32 38, ; 68
	i32 145, ; 69
	i32 80, ; 70
	i32 42, ; 71
	i32 48, ; 72
	i32 117, ; 73
	i32 113, ; 74
	i32 131, ; 75
	i32 4, ; 76
	i32 122, ; 77
	i32 46, ; 78
	i32 34, ; 79
	i32 101, ; 80
	i32 111, ; 81
	i32 100, ; 82
	i32 89, ; 83
	i32 55, ; 84
	i32 29, ; 85
	i32 140, ; 86
	i32 59, ; 87
	i32 82, ; 88
	i32 107, ; 89
	i32 128, ; 90
	i32 19, ; 91
	i32 27, ; 92
	i32 97, ; 93
	i32 97, ; 94
	i32 128, ; 95
	i32 126, ; 96
	i32 27, ; 97
	i32 30, ; 98
	i32 53, ; 99
	i32 109, ; 100
	i32 133, ; 101
	i32 0, ; 102
	i32 84, ; 103
	i32 108, ; 104
	i32 55, ; 105
	i32 24, ; 106
	i32 136, ; 107
	i32 123, ; 108
	i32 7, ; 109
	i32 35, ; 110
	i32 72, ; 111
	i32 8, ; 112
	i32 12, ; 113
	i32 62, ; 114
	i32 68, ; 115
	i32 44, ; 116
	i32 20, ; 117
	i32 105, ; 118
	i32 143, ; 119
	i32 141, ; 120
	i32 118, ; 121
	i32 121, ; 122
	i32 112, ; 123
	i32 92, ; 124
	i32 100, ; 125
	i32 141, ; 126
	i32 119, ; 127
	i32 114, ; 128
	i32 115, ; 129
	i32 146, ; 130
	i32 93, ; 131
	i32 90, ; 132
	i32 15, ; 133
	i32 61, ; 134
	i32 26, ; 135
	i32 98, ; 136
	i32 71, ; 137
	i32 104, ; 138
	i32 17, ; 139
	i32 147, ; 140
	i32 98, ; 141
	i32 51, ; 142
	i32 133, ; 143
	i32 32, ; 144
	i32 79, ; 145
	i32 124, ; 146
	i32 95, ; 147
	i32 120, ; 148
	i32 36, ; 149
	i32 147, ; 150
	i32 93, ; 151
	i32 78, ; 152
	i32 22, ; 153
	i32 104, ; 154
	i32 143, ; 155
	i32 32, ; 156
	i32 84, ; 157
	i32 60, ; 158
	i32 6, ; 159
	i32 30, ; 160
	i32 137, ; 161
	i32 65, ; 162
	i32 96, ; 163
	i32 2, ; 164
	i32 149, ; 165
	i32 86, ; 166
	i32 49, ; 167
	i32 114, ; 168
	i32 122, ; 169
	i32 47, ; 170
	i32 4, ; 171
	i32 20, ; 172
	i32 68, ; 173
	i32 124, ; 174
	i32 123, ; 175
	i32 91, ; 176
	i32 66, ; 177
	i32 2, ; 178
	i32 34, ; 179
	i32 116, ; 180
	i32 36, ; 181
	i32 43, ; 182
	i32 49, ; 183
	i32 13, ; 184
	i32 28, ; 185
	i32 9, ; 186
	i32 83, ; 187
	i32 16, ; 188
	i32 44, ; 189
	i32 67, ; 190
	i32 127, ; 191
	i32 14, ; 192
	i32 83, ; 193
	i32 42, ; 194
	i32 145, ; 195
	i32 54, ; 196
	i32 54, ; 197
	i32 31, ; 198
	i32 136, ; 199
	i32 131, ; 200
	i32 95, ; 201
	i32 58, ; 202
	i32 37, ; 203
	i32 70, ; 204
	i32 75, ; 205
	i32 35, ; 206
	i32 105, ; 207
	i32 63, ; 208
	i32 110, ; 209
	i32 64, ; 210
	i32 134, ; 211
	i32 45, ; 212
	i32 1, ; 213
	i32 22, ; 214
	i32 130, ; 215
	i32 148, ; 216
	i32 10, ; 217
	i32 90, ; 218
	i32 31, ; 219
	i32 80, ; 220
	i32 99, ; 221
	i32 102, ; 222
	i32 70, ; 223
	i32 63, ; 224
	i32 139, ; 225
	i32 134, ; 226
	i32 24, ; 227
	i32 117, ; 228
	i32 25, ; 229
	i32 33, ; 230
	i32 135, ; 231
	i32 37, ; 232
	i32 3, ; 233
	i32 130, ; 234
	i32 40, ; 235
	i32 88, ; 236
	i32 140, ; 237
	i32 17, ; 238
	i32 16, ; 239
	i32 33, ; 240
	i32 67, ; 241
	i32 1, ; 242
	i32 41, ; 243
	i32 110, ; 244
	i32 119, ; 245
	i32 18, ; 246
	i32 109, ; 247
	i32 112, ; 248
	i32 23, ; 249
	i32 39, ; 250
	i32 66, ; 251
	i32 41, ; 252
	i32 102, ; 253
	i32 5, ; 254
	i32 74, ; 255
	i32 144, ; 256
	i32 142, ; 257
	i32 6, ; 258
	i32 46, ; 259
	i32 89, ; 260
	i32 25, ; 261
	i32 144, ; 262
	i32 19, ; 263
	i32 43, ; 264
	i32 51, ; 265
	i32 79, ; 266
	i32 56, ; 267
	i32 18, ; 268
	i32 103, ; 269
	i32 137, ; 270
	i32 26, ; 271
	i32 0, ; 272
	i32 77, ; 273
	i32 96, ; 274
	i32 76, ; 275
	i32 99, ; 276
	i32 21, ; 277
	i32 121, ; 278
	i32 103, ; 279
	i32 11, ; 280
	i32 11, ; 281
	i32 9, ; 282
	i32 21, ; 283
	i32 75, ; 284
	i32 73, ; 285
	i32 127, ; 286
	i32 129, ; 287
	i32 12, ; 288
	i32 5, ; 289
	i32 87, ; 290
	i32 139, ; 291
	i32 76, ; 292
	i32 108, ; 293
	i32 94, ; 294
	i32 78, ; 295
	i32 15, ; 296
	i32 14, ; 297
	i32 10, ; 298
	i32 57 ; 299
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

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
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" }

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
