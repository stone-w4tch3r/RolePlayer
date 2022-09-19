namespace RolePlayer.Model.API.Interfaces;

public interface IDatabaseController
{
    public Task AddStoryAsync(IStory story);
    public Task AddTracksAsync(IEnumerable<ITrack> tracks);
    public Task RemoveStoryAsync(IStory story);
    public Task RemoveTracksAsync(IEnumerable<ITrack> tracks);
    public IEnumerable<IStory> GetAllStories();
    public IEnumerable<ITrack> GetAllTracks();
}