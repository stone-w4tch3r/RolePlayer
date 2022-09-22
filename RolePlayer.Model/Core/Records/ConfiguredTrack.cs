using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Core.Records;

internal record ConfiguredTrack(ITrack Track, string Title, string Comment, ISegment SegmentToPlay) : IConfiguredTrack;