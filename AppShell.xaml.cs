using Namada_Maui.Views.Blocks;
using Namada_Maui.Views.Overviews;
using Namada_Maui.Views.Settings;
using Namada_Maui.Views.Tracks;
using Namada_Maui.Views.Validators;

namespace Namada_Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute(nameof(OverviewPage), typeof(OverviewPage));
            Routing.RegisterRoute(nameof(TrackPage), typeof(TrackPage));
            Routing.RegisterRoute(nameof(ValidatorsPage), typeof(ValidatorsPage));
            Routing.RegisterRoute(nameof(InfoValidatorsPage), typeof(InfoValidatorsPage));
            Routing.RegisterRoute(nameof(BlocksPage), typeof(BlocksPage));
            Routing.RegisterRoute(nameof(InfoBlocksPage), typeof(InfoBlocksPage));

            #region Settings

            Routing.RegisterRoute(nameof(SettingPage), typeof(SettingPage));
            Routing.RegisterRoute(nameof(ApiPage), typeof(ApiPage));
            Routing.RegisterRoute(nameof(LocalizationPage), typeof(LocalizationPage));
            Routing.RegisterRoute(nameof(ThemePage), typeof(ThemePage));

            #endregion

            InitializeComponent();
        }
    }
}
