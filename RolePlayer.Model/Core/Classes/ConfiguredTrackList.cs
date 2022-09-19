using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Model.Classes;

internal record ConfiguredTrackList(IEnumerable<IConfiguredTrack> Tracks) : IConfiguredTrackList;