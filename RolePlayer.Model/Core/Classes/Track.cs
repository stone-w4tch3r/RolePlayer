using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Model.Classes;

internal record Track(string FileName, string Path) : ITrack
{
    public virtual bool Equals(ITrack? other) => Equals((Track?)other);
}