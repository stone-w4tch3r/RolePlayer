using System.Text.Json;

namespace RolePlayer.Model.Core.Infrastructure.Classes;

internal class FileWorker
{
    public void WriteObjectToJsonFile<T>(T obj, FileInfo fileInfo)
    {
        var options = new JsonSerializerOptions() { WriteIndented = true };
        using var stream = File.Create(fileInfo.FullName);
        JsonSerializer.Serialize(stream, obj, options);
        stream.Dispose();
    }
}