using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Core.Records;

internal record Database(IEnumerable<IStory> Stories, IEnumerable<ITrack> Tracks) : IDatabase;