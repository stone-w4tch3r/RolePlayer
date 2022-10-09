using System.Text.Json;
using RolePlayer.Essentials.Classes;
using RolePlayer.Essentials.Interfaces;
using RolePlayer.Model.API.Interfaces;
using RolePlayer.Model.Core.Records;

namespace RolePlayer.Model.API;

public class DatabaseController : IDatabaseController
{
    private readonly IWrapper<IDatabase> _wrappedDb;
    private DatabaseController(IDatabase db, FileInfo dbFileInfo, IFileWorker fileWorker)
    {
        _wrappedDb = new OnChangeActingWrapper<IDatabase, FileInfo>
            (db, fileWorker.WriteObjectToJsonFileAsync, dbFileInfo);
    }
    public static async Task<DatabaseController> InitializeAsync(FileInfo dbFileInfo, IFileWorker fileWorker)
    {
        IDatabase db;
        if (!dbFileInfo.Exists)
            db = new Database(Enumerable.Empty<IStory>(), Enumerable.Empty<ITrack>());
        else
            db = await fileWorker.ReadObjectFromJsonFileAsync<IDatabase>(dbFileInfo).ConfigureAwait(false);
        return new DatabaseController(db, dbFileInfo, fileWorker);
    }
    public void AddStoryAsync(IStory story) => 
        _wrappedDb.Value = new Database(_wrappedDb.Value.Stories.Append(story), _wrappedDb.Value.Tracks);
    public void AddTracksAsync(IEnumerable<ITrack> tracks) =>
        _wrappedDb.Value = new Database(_wrappedDb.Value.Stories, _wrappedDb.Value.Tracks.Concat(tracks));
    public void RemoveStoryAsync(IStory story) =>
        _wrappedDb.Value = new Database(_wrappedDb.Value.Stories.Where(s => 
            !s.Equals(story)), _wrappedDb.Value.Tracks);
    public void RemoveTracksAsync(IEnumerable<ITrack> tracks) =>
        _wrappedDb.Value = new Database(_wrappedDb.Value.Stories, _wrappedDb.Value.Tracks.Except(tracks));
    public IEnumerable<IStory> GetAllStories() => _wrappedDb.Value.Stories;
    public IEnumerable<ITrack> GetAllTracks() => _wrappedDb.Value.Tracks;
}