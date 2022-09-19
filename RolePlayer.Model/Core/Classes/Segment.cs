using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Model.Classes;

internal record Segment(ITrackTime StartTime, ITrackTime EndTime) : ISegment;