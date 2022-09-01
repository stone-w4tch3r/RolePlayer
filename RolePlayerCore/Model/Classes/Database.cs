using RolePlayerCore.Interfaces;

namespace RolePlayerCore.Model;

internal class Database : IDatabase
{
    public IEnumerable<IStory> Stories { get; }
    public IEnumerable<ITrack> Tracks { get; }

    public Database(IEnumerable<IStory> stories, IEnumerable<ITrack> tracks)
    {
        Stories = stories;
        Tracks = tracks;
    }
}