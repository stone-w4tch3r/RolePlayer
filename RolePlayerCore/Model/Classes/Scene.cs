using RolePlayerCore.API.Interfaces;

namespace RolePlayerCore.Model.Classes;

internal record Scene(IConfiguredTrackList Tracklist) : IScene;