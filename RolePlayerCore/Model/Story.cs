using RolePlayerCore.Interfaces;

namespace RolePlayerCore.Model;
internal class Story : IStory
{
    public IEnumerable<ISession> Sessions => throw new NotImplementedException();

    public Guid Id => throw new NotImplementedException();

    public string Title => throw new NotImplementedException();

    public bool Equals(IStory? other) => throw new NotImplementedException();
}
