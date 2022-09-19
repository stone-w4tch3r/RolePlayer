namespace RolePlayer.Model.API.Interfaces;

public interface IDatabase
{
    public IEnumerable<IStory> Stories { get; }
    public IEnumerable<ITrack> Tracks { get; }
}