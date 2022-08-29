using RolePlayerCore.API.Interfaces;

namespace RolePlayerCore.Interfaces;

public interface IStory : IEquatable<IStory>, IEntity
{
    public IEnumerable<ISession> Sessions { get; }

    public string Title { get; }
}