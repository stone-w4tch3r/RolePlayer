using Microsoft.Extensions.Logging;

namespace RolePlayer.MAUI.Core.FunctionalExtensions;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder AddDebugToLogging(this MauiAppBuilder builder)
    {
        builder.Logging.AddDebug();
        return builder;
    }
}