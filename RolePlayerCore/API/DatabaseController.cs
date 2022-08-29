using RolePlayerCore.API.Interfaces;
using RolePlayerCore.Interfaces;
using RolePlayerCore.Model;
using System.Text.Json;

namespace RolePlayerCore.API;

public class DatabaseController : IDatabaseController
{
    private IDatabase _database;

    public DatabaseController(string path)
    {
        if (File.Exists(path))
            _database = JsonSerializer.Deserialize<IDatabase>(File.ReadAllText(path)) ?? throw new JsonException();
        else
            _database = new Database();
    }

    public void AddStory(IStory story) => _database.Stories = _database.Stories.Append(story);

    public void AddTracks(IEnumerable<ITrack> tracks) => _database.Tracks = _database.Tracks.Concat(tracks);

    public IEnumerable<IStory> GetAllStories() => _database.Stories;

    public IEnumerable<ITrack> GetAllTracks() => _database.Tracks;

    public void RemoveStory(IStory story) => _database.Stories = _database.Stories.Where(s => s.Equals(story));

    public void RemoveTracks(IEnumerable<ITrack> tracks)
    {
        throw new NotImplementedException();
    }
}
