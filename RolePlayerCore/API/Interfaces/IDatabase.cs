using RolePlayerCore.Interfaces;

namespace RolePlayerCore.Model;

public interface IDatabase
{
    public IEnumerable<IStory> Stories { get; }
    public IEnumerable<ITrack> Tracks { get; }
}