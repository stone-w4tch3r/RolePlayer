namespace RolePlayerCore.API.Interfaces;

public interface IStory : IEquatable<IStory>
{
    public IEnumerable<ISession> Sessions { get; }

    public string Title { get; }
}