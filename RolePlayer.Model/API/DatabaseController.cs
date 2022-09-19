using System.Text.Json;
using RolePlayer.Model.API.Interfaces;
using RolePlayer.Model.Model.Classes;

namespace RolePlayer.Model.API;

public class DatabaseController : IDatabaseController
{
    private readonly FileInfo _databaseFileInfo;
    private IDatabase _db = null!;
    private DatabaseController(IDatabase db, FileInfo dbFileInfo)
    {
        Database = db;
        _databaseFileInfo = dbFileInfo;
    }
    public static async Task<DatabaseController> InitializeAsync(FileInfo dbFileInfo)
    {
        Database db;
        if (!dbFileInfo.Exists)
            db = new Database(Enumerable.Empty<IStory>(), Enumerable.Empty<ITrack>());
        else
            db = await JsonSerializer.DeserializeAsync<Database>(dbFileInfo.OpenRead()).ConfigureAwait(false)
                 ?? new Database(Enumerable.Empty<IStory>(), Enumerable.Empty<ITrack>());
        return new DatabaseController(db, dbFileInfo);
    }
    public void AddStoryAsync(IStory story) => 
        Database = new Database(Database.Stories.Append(story), Database.Tracks);
    public void AddTracksAsync(IEnumerable<ITrack> tracks) =>
        Database = new Database(Database.Stories, Database.Tracks.Concat(tracks));
    public void RemoveStoryAsync(IStory story) =>
        Database = new Database(Database.Stories.Where(s => !s.Equals(story)), Database.Tracks);
    public void RemoveTracksAsync(IEnumerable<ITrack> tracks) =>
        Database = new Database(Database.Stories, Database.Tracks.Except(tracks));
    public IEnumerable<IStory> GetAllStories() => Database.Stories;
    public IEnumerable<ITrack> GetAllTracks() => Database.Tracks;
    private IDatabase SetDatabase(IDatabase db, FileInfo dbFileInfo)
    {
        _db = db;
        WriteDbAsync(_db, dbFileInfo);
        return _db;
    }
    private void WriteDbAsync(IDatabase db, FileInfo dbFileInfo)
    {
         var options = new JsonSerializerOptions() { WriteIndented = true };
         using var stream = File.Create(dbFileInfo.FullName);
         JsonSerializer.Serialize(stream, db, options);
         stream.Dispose();
    }
}