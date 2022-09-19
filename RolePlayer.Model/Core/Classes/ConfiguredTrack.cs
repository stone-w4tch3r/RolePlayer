using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Model.Classes;

internal record ConfiguredTrack(ITrack Track, string Title, string Comment, ISegment SegmentToPlay) : IConfiguredTrack;