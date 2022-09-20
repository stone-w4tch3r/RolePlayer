using System.Text.Json;
using RolePlayer.Model.API.Interfaces;
using RolePlayer.Model.Core.Interfaces;

namespace RolePlayer.Model.Core.Classes;

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