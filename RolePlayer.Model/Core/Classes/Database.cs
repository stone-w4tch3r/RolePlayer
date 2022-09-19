using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Model.Classes;

internal record Database(IEnumerable<IStory> Stories, IEnumerable<ITrack> Tracks) : IDatabase;