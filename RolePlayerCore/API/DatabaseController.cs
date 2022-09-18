using RolePlayerCore.API.Interfaces;
using RolePlayerCore.Model.Classes;
using System.Text.Json;

namespace RolePlayerCore.API;

public class DatabaseController : IDatabaseController
{
    private IDatabase _db;
    private readonly FileInfo _dbFileInfo;
    public static async Task<DatabaseController> InitializeAsync(FileInfo dbFileInfo)
    {
        Database db;
        if (!dbFileInfo.Exists)
            db = new Database(Enumerable.Empty<IStory>(), Enumerable.Empty<ITrack>());
        else
            db = await JsonSerializer.DeserializeAsync<Database>(dbFileInfo.OpenRead())
                ?? new Database(Enumerable.Empty<IStory>(), Enumerable.Empty<ITrack>());
        return new DatabaseController(db, dbFileInfo);
    }
    private DatabaseController(IDatabase db, FileInfo dbFileInfo)
    {
        _db = db;
        _dbFileInfo = dbFileInfo;
    }
    public async Task AddStoryAsync(IStory story)
    {
        _db = new Database(_db.Stories.Append(story), _db.Tracks);
        await WriteDbAsync(_db).ConfigureAwait(false);
    }
    public async Task AddTracksAsync(IEnumerable<ITrack> tracks)
    {
        _db = new Database(_db.Stories, _db.Tracks.Concat(tracks));
        await WriteDbAsync(_db).ConfigureAwait(false);
    }
    public async Task RemoveStoryAsync(IStory story)
    {
        _db = new Database(_db.Stories.Where(s => !s.Equals(story)), _db.Tracks);
        await WriteDbAsync(_db).ConfigureAwait(false);
    }
    public async Task RemoveTracksAsync(IEnumerable<ITrack> tracks)
    {
        _db = new Database(_db.Stories, _db.Tracks.Except(tracks));
        await WriteDbAsync(_db).ConfigureAwait(false);
    }
    private async Task WriteDbAsync(IDatabase db) => await JsonSerializer.SerializeAsync(_dbFileInfo.OpenWrite(), db);
    public IEnumerable<IStory> GetAllStories() => _db.Stories;
    public IEnumerable<ITrack> GetAllTracks() => _db.Tracks;
}