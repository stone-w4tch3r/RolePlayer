namespace RolePlayerCore.API.Interfaces;

public interface IConfiguredTrack
{
    public ITrack Track { get; }
    public string Title { get; }
    public string Comment { get; }
    public ISegment SegmentToPlay { get; }
}