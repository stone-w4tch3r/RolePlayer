namespace RolePlayer.Model.API.Interfaces;

public interface ISegment
{
    public ITrackTime StartTime { get; }
    public ITrackTime EndTime { get; }
}