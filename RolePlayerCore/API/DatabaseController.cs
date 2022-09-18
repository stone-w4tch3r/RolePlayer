using RolePlayerCore.API.Interfaces;
using RolePlayerCore.Model.Classes;
using System.Text.Json;

namespace RolePlayerCore.API;

public class DatabaseController : IDatabaseController
{
    private IDatabase _db;
    public static DatabaseController InitializeAsync(FileInfo dbFileInfo)
    {
        var db = JsonSerializer.Deserialize<Database>(dbFileInfo.FullName) 
            ?? new Database(Enumerable.Empty<IStory>(), Enumerable.Empty<ITrack>());
        return new DatabaseController(db);
    }
    private DatabaseController(IDatabase db)
    {
        _db = db;
    }
    public void AddStory(IStory story) => _db = new Database(_db.Stories.Append(story), _db.Tracks);
    public void AddTracks(IEnumerable<ITrack> tracks) => _db = new Database(_db.Stories, _db.Tracks.Concat(tracks));
    public void RemoveStory(IStory story) => _db = new Database(_db.Stories.Where(s => !s.Equals(story)), _db.Tracks);
    public void RemoveTracks(IEnumerable<ITrack> tracks) => _db = new Database(_db.Stories, _db.Tracks.Except(tracks));
    public IEnumerable<IStory> GetAllStories() => _db.Stories;
    public IEnumerable<ITrack> GetAllTracks() => _db.Tracks;
}