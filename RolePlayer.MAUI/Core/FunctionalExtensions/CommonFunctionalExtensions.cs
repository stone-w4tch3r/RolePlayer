namespace RolePlayer.MAUI.Core.FunctionalExtensions;

public static class CommonFunctionalExtensions
{
    public static T Tap<T>(this T obj, Action<T> action)
    {
        action(obj);
        return obj;
    }
}