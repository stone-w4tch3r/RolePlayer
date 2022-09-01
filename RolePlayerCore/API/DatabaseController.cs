using RolePlayerCore.API.Interfaces;
using RolePlayerCore.Interfaces;
using RolePlayerCore.Model;
using System.Text.Json;

namespace RolePlayerCore.API;

public class DatabaseController : IDatabaseController
{
    public IDatabase AddStory(IDatabase db, IStory story) => new Database(db.Stories.Append(story), db.Tracks);
    public IDatabase AddTracks(IDatabase db, IEnumerable<ITrack> tracks) => new Database(db.Stories, db.Tracks.Concat(tracks));
    public IDatabase RemoveStory(IDatabase db, IStory story) => new Database(db.Stories.Where(s => !s.Equals(story)), db.Tracks);
    public IDatabase RemoveTracks(IDatabase db, IEnumerable<ITrack> tracks) => new Database(db.Stories, db.Tracks.Except(tracks));
    public IEnumerable<IStory> GetAllStories(IDatabase db) => db.Stories;
    public IEnumerable<ITrack> GetAllTracks(IDatabase db) => db.Tracks;
}
