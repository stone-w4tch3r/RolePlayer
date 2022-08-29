using RolePlayerCore.Interfaces;

namespace RolePlayerCore.Model;
internal class Database : IDatabase
{
    //internal IEnumerable<IStory> Stories { get; set; }

    //internal IEnumerable<ITrack> Tracks {get; set; }
    IEnumerable<IStory> IDatabase.Stories {get; set;}
    IEnumerable<ITrack> IDatabase.Tracks {get; set;}
}