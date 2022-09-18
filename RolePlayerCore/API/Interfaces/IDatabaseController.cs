namespace RolePlayerCore.API.Interfaces;

public interface IDatabaseController
{
    public void AddStory(IStory story);
    public void AddTracks(IEnumerable<ITrack> tracks);
    public void RemoveStory(IStory story);
    public void RemoveTracks(IEnumerable<ITrack> tracks);
    public IEnumerable<IStory> GetAllStories();
    public IEnumerable<ITrack> GetAllTracks();
}