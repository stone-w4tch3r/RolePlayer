using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Core.Records;

internal record Segment(ITrackTime StartTime, ITrackTime EndTime) : ISegment;