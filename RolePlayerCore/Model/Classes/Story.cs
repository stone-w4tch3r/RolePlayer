using RolePlayerCore.Interfaces;

namespace RolePlayerCore.Model;

internal class Story : IStory
{
    public IEnumerable<ISession> Sessions { get; }
    public string Title { get; }
    public Guid Id { get; }

    public Story(IEnumerable<ISession> sessions, string title, Guid id)
    {
        Sessions = sessions;
        Title = title;
        Id = id;
    }

    public Story(IEnumerable<ISession> sessions, string title)
    {
        Sessions = sessions;
        Title = title;
        Id = Guid.NewGuid();
    }

    public bool Equals(IStory? other) => Id == other?.Id;
}