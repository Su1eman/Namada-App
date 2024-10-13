using CommunityToolkit.Maui;
using Plugin.LocalNotification;
using Microsoft.Extensions.Logging;
using Namada_Maui.Services;

namespace Namada_Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            FormHandler.RemoveBorders();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLocalNotification()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("fa_solid.ttf", "FontAwesome");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<HttpClient>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}