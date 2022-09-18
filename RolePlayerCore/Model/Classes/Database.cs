using RolePlayerCore.API.Interfaces;

namespace RolePlayerCore.Model.Classes;

internal record Database(IEnumerable<IStory> Stories, IEnumerable<ITrack> Tracks) : IDatabase;