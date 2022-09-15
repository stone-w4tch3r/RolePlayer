namespace RolePlayerCore.API.Interfaces;

public interface IConfiguredTrackList
{
    public IEnumerable<IConfiguredTrack> Tracks { get; }
}