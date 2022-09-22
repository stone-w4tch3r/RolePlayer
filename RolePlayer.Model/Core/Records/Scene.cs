using RolePlayer.Model.API.Interfaces;

namespace RolePlayer.Model.Core.Records;

internal record Scene(IConfiguredTrackList Tracklist) : IScene;