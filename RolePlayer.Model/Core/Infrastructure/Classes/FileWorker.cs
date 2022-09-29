using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using RolePlayer.Model.API.Interfaces;
// ReSharper disable MemberCanBeMadeStatic.Global

namespace RolePlayer.Model.Core.Infrastructure.Classes;

[SuppressMessage("Performance", "CA1822:Mark members as static")]
internal class FileWorker : IFileWorker
{
    public async void WriteObjectToJsonFile<T>(T obj, FileInfo fileInfo)
    {
        var options = new JsonSerializerOptions() { WriteIndented = true };
        await using var stream = File.Create(fileInfo.FullName);
        await JsonSerializer.SerializeAsync(stream, obj, options).ConfigureAwait(false);
    }
    
    public async Task<T> ReadObjectFromJsonFile<T>(FileInfo fileInfo)
    {
        await using var stream = File.Open(fileInfo.FullName, FileMode.Open);
        var result = await JsonSerializer.DeserializeAsync<T>(stream).ConfigureAwait(false)
                     ?? throw new JsonException($"Failed To Deserialize {fileInfo.FullName}");
        return result;
    }
}