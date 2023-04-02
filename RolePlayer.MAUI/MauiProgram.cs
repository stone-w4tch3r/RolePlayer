using MauiIcons.Fluent;
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
            .UseFluentMauiIcons()
#if DEBUG
            .Map(x =>
            {
                x.Logging.AddDebug();
                return x;
            })
#endif
            .Build();
}