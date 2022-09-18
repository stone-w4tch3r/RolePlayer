using RolePlayerCore.API.Interfaces;

namespace RolePlayerCore.Model.Classes;

internal record Segment(ITrackTime StartTime, ITrackTime EndTime) : ISegment;