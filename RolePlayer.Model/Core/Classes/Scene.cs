using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Model.Classes;

internal record Scene(IConfiguredTrackList Tracklist) : IScene;