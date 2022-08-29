namespace RolePlayerCore.Interfaces;

public interface IStory
{
    public List<ISession> Sessions { get; }

    public string Title { get; }

    public bool Equals(object? obj);
}