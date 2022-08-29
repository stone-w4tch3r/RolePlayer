using RolePlayerCore.Interfaces;

namespace RolePlayerCore.API.Interfaces;

public interface IDatabaseController
{
    public void AddTracks(IEnumerable<ITrack> tracks);
    public void RemoveTracks(IEnumerable<ITrack> tracks);
    public IEnumerable<ITrack> GetAllTracks();
    public void AddStory(IStory story);
    public void RemoveStory(IStory story);
    public IEnumerable<IStory> GetAllStories();
}