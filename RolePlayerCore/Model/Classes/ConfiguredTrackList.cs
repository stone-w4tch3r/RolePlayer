using RolePlayerCore.API.Interfaces;

namespace RolePlayerCore.Model.Classes;

internal record ConfiguredTrackList(IEnumerable<IConfiguredTrack> Tracks) : IConfiguredTrackList;