namespace RolePlayer.Model.API.Interfaces;

public interface IDatabaseController
{
    public void AddStoryAsync(IStory story);
    public void AddTracksAsync(IEnumerable<ITrack> tracks);
    public void RemoveStoryAsync(IStory story);
    public void RemoveTracksAsync(IEnumerable<ITrack> tracks);
    public IEnumerable<IStory> GetAllStories();
    public IEnumerable<ITrack> GetAllTracks();
}