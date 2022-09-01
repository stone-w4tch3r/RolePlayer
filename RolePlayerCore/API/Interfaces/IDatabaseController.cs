using RolePlayerCore.Interfaces;
using RolePlayerCore.Model;

namespace RolePlayerCore.API.Interfaces;

public interface IDatabaseController
{
    public IDatabase AddStory(IDatabase database, IStory story);
    public IDatabase AddTracks(IDatabase database, IEnumerable<ITrack> tracks);
    public IDatabase RemoveStory(IDatabase database, IStory story);
    public IDatabase RemoveTracks(IDatabase database, IEnumerable<ITrack> tracks);
    public IEnumerable<IStory> GetAllStories(IDatabase database);
    public IEnumerable<ITrack> GetAllTracks(IDatabase database);
}