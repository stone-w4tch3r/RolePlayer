namespace RolePlayerCore.Interfaces;

public interface IConfiguredTrack
{
    public ITrack Track { get; }
    public string Title { get; }
    public string Comment { get; set; }
    public ISegment SegmentToPlay { get; set; }
}