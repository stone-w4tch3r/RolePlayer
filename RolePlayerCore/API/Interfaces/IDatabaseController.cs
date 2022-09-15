namespace RolePlayerCore.API.Interfaces;

public interface IDatabaseController
{
    public IDatabase AddStory(IDatabase db, IStory story);
    public IDatabase AddTracks(IDatabase db, IEnumerable<ITrack> tracks);
    public IDatabase RemoveStory(IDatabase db, IStory story);
    public IDatabase RemoveTracks(IDatabase db, IEnumerable<ITrack> tracks);
    public IEnumerable<IStory> GetAllStories(IDatabase db);
    public IEnumerable<ITrack> GetAllTracks(IDatabase db);
}