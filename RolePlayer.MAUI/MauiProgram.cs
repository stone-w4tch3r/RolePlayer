using Microsoft.Extensions.Logging;
using RolePlayer.MAUI.Core.FunctionalExtensions;

namespace RolePlayer.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp() =>
        MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
#if DEBUG
            .Tap(x => x.Logging.AddDebug())
#endif
            .Build();
}