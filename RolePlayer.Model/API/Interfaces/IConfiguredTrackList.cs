namespace RolePlayer.Model.API.Interfaces;

public interface IConfiguredTrackList
{
    public IEnumerable<IConfiguredTrack> Tracks { get; }
}