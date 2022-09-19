namespace RolePlayer.Model.API.Interfaces;

public interface ITrack : IEquatable<ITrack>
{
    public string FileName { get; }
    public string Path { get; }
}