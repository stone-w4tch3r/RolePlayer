using RolePlayerCore.API.Interfaces;

namespace RolePlayerCore.Model.Classes;

internal record ConfiguredTrack(ITrack Track, string Title, string Comment, ISegment SegmentToPlay) : IConfiguredTrack;