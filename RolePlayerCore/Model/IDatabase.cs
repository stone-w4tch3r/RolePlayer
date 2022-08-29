using RolePlayerCore.Interfaces;

namespace RolePlayerCore.Model;

internal interface IDatabase
{
    internal IEnumerable<IStory> Stories { get; set; }
    internal IEnumerable<ITrack> Tracks { get; set; }
}