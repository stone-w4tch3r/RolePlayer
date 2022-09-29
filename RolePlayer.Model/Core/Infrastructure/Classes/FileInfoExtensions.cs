namespace RolePlayer.Model.Core.Infrastructure.Classes;

public static class FileInfoExtensions
{
    internal static FileInfo RefreshImmediately(this FileInfo fileInfo)
    {
        fileInfo.Refresh();
        return fileInfo;
    }
}