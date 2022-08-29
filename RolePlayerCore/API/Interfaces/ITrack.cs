using RolePlayerCore.API.Interfaces;

namespace RolePlayerCore.Interfaces;

public interface ITrack : IEquatable<ITrack>, IEntity
{
    public string FileName { get; }
    public string Path { get; }
}