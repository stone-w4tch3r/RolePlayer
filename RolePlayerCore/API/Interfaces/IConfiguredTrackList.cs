namespace RolePlayerCore.Interfaces;

public interface IConfiguredTrackList
{
    public IEnumerable<IConfiguredTrack> Tracks { get; }
}