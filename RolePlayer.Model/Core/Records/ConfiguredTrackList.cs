using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Core.Records;

internal record ConfiguredTrackList(IEnumerable<IConfiguredTrack> Tracks) : IConfiguredTrackList;