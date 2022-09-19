using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Model.Classes;

internal record Story(IEnumerable<ISession> Sessions, string Title) : IStory
{
    public virtual bool Equals(IStory? other) => Equals((Story?)other);
}